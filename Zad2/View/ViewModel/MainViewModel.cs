using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using View.FuzzyLogic;
using Microsoft.Win32;
using System;
using Zad2;
using Zad2.FuzzyLogic;
using System.Threading.Tasks;
using System.Text;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Player> dataContext;
        public ObservableCollection<LinguisticVariable> LinguisticVariables { get; set; }

        public LinguisticVariable SelectedQualifier { get; set; }
        public LinguisticVariable SelectedSummarizer1 { get; set; }
        public LinguisticVariable SelectedSummarizer2 { get; set; }
        private ObservableCollection<LinguisticVariable> quantifiers;
        public ObservableCollection<LinguisticVariable> Andor { get; set; }

        public LinguisticVariable SelectedFunction { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand GenerateCommand { get; set; }
        public ICommand Generate2Command { get; set; }
        public ICommand SaveCommand { get; set; }
        public List<KeyValuePair<double, (string summary, List<double> tValues)>> Summaries { get; private set; }
        public string Output
        {
            get => output;
            private set
            {
                output = value;
                OnPropertyChanged("Output");
            }
        }
        private string output;

        public MainViewModel()
        {
        }

        public MainViewModel(List<Player> dataContext)
        {
            this.dataContext = dataContext;
            LinguisticVariables = StaticVariables.getAllVariables();
            quantifiers = StaticQuantifiers.getAllQuantifiers();
            GenerateCommand = new RelayCommand(o => Generate());
            Generate2Command = new RelayCommand(o => Generate2());
            SaveCommand = new RelayCommand(o => Save());
            Andor = new ObservableCollection<LinguisticVariable>
            {
                new LinguisticVariable
                {
                    Name = " OR ",
                    FuzzySet = new Or()
                },
                new LinguisticVariable
                {
                    Name = " AND ",
                    FuzzySet = new And()
                }
            };
        }

        private void Generate()
        {
            Summaries = new List<KeyValuePair<double, (string, List<double>)>>();
            foreach (LinguisticVariable quantifier in quantifiers)
            {
                string w = GetQualifierString(SelectedQualifier.MemberAndName);
                string summary = quantifier.Name + w + " are/have " + SelectedSummarizer1.MemberAndName;
                var pair = CreateSummaryPair(quantifier, SelectedSummarizer1, summary);
                Summaries.Add(pair);
            }
            Summaries.Sort((x, y) => y.Key.CompareTo(x.Key));
            Output = GenerateSummarySentences();
        }

        private string GetQualifierString(string name)
        {
            return name.Equals("Every: Every") ? "" : " of soccer players being/having " + name;
        }

        private KeyValuePair<double, (string, List<double>)> CreateSummaryPair(LinguisticVariable quantifier, LinguisticVariable summarizer, string summary)
        {
            List<double> measureValues;
            var weightedMeasure = Measures.WeightedMeasure(quantifier, SelectedQualifier, summarizer, dataContext, out measureValues);
            var pair = new KeyValuePair<double, (string, List<double>)>(
                weightedMeasure,
                (summary, measureValues)
            );
            return pair;
        }

        private void Generate2()
        {
            Summaries = new List<KeyValuePair<double, (string, List<double>)>>();
            SelectedFunction.FuzzySet.SetAllFuzzySets(new List<FuzzySet> { SelectedSummarizer1.FuzzySet, SelectedSummarizer2.FuzzySet });
            foreach (LinguisticVariable quantifier in quantifiers)
            {
                string summary = quantifier.Name + " of soccer players being/having " + SelectedQualifier.MemberAndName + " are/have " +
                    SelectedSummarizer1.MemberAndName + SelectedFunction.Name + SelectedSummarizer2.MemberAndName;
                var pair = CreateSummaryPair(quantifier, SelectedFunction, summary);
                Summaries.Add(pair);
            }
            Summaries.Sort((x, y) => y.Key.CompareTo(x.Key));
            Output = GenerateSummarySentences();
        }

        private string GenerateSummarySentences()
        {
            string res = "";
            foreach (var summary in Summaries)
            {
                LogTValues(summary);
                int i = 1;
                res += summary.Value.summary + " [" + Math.Round(summary.Key, 3) + "]\n";
                res += "[";
                summary.Value.tValues.ForEach((v) =>
                {
                    res += "T" + i++ + "=" + Math.Round(v, 3) + "; ";
                });
                res = res.Substring(0, res.Length - 2);
                res += "]\n";
            }

            return res;
        }

        private void LogTValues(KeyValuePair<double, (string summary, List<double> tValues)> summary)
        {
            string log = summary.Value.summary + "; " + Math.Round(summary.Key, 3) + "; ";
            summary.Value.tValues.ForEach((v) => log += Math.Round(v, 3) + "; ");
            System.Diagnostics.Trace.WriteLine(log.Substring(0, log.Length - 2));
        }

        private string ExtractQuantifier(string summary)
        {
            foreach(LinguisticVariable quantifier in quantifiers)
            {
                if (summary.Contains(quantifier.Name)) return quantifier.Name;
            }
            return "";
        }

        private void Save()
        {
            Task.Run(() => {
                string messageToSave = SelectedQualifier.MemberAndName + " -> " + SelectedSummarizer1.MemberAndName;
            if (SelectedFunction != null && SelectedSummarizer2 != null) messageToSave += " " + SelectedFunction.Name + " " + SelectedSummarizer2.MemberAndName;

                messageToSave += ";Q;T_ALL;T1;T2;T3;T4;T5;T6;T7;T8;T9;T10;T11;\n";

                Summaries.ForEach((s) => {
                    messageToSave += s.Value.summary + ";" + ExtractQuantifier(s.Value.summary) + ";" + s.Key + ";";
                    s.Value.tValues.ForEach((w) => messageToSave += w + ";");
                    messageToSave += "\n";
                });

                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "CSV file(.csv) | *.csv"
                };

                dialog.ShowDialog();
                string path = dialog.FileName;
                File.WriteAllText(path, messageToSave, Encoding.UTF8);
            });
        
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

