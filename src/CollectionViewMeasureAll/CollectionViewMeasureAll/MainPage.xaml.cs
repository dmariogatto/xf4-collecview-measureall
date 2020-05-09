using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollectionViewMeasureAll
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private List<string> _randomText = new List<string>() { "lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit", "aliquam", "et", "urna", "mauris", "donec", "commodo", "orci", "sed", "varius", "condimentum", "maecenas", "vel", "tellus", "vitae", "nisi", "mattis", "volutpat", "pretium", "velit", "eu", "vulputate", "nunc", "massa", "ac", "laoreet", "diam", "gravida", "in", "proin", "tempor", "id", "risus", "nec", "vehicula", "quam", "suspendisse", "potenti", "nullam", "erat", "bibendum", "sem", "rhoncus", "lectus", "non", "nisl", "ut", "ullamcorper", "maximus", "neque", "etiam", "sapien" };
        private Random _rng = new Random();

        public MainPage()
        {
            InitializeComponent();

            MyCollectionView.SetBinding(
                CollectionView.ItemsSourceProperty,
                new Binding(nameof(Items), source: this));

            Device.StartTimer(TimeSpan.FromSeconds(1.5), () =>
            {
                var wordCount = _rng.Next(1, 30);
                var words = new List<string>();
                
                for (var i = 0; i < wordCount; i++)
                {
                    words.Add(_randomText[_rng.Next(0, _randomText.Count - 1)]);
                }

                Items.Add(string.Join(" ", words));

                return true;
            });
        }

        public ObservableCollection<string> Items { get; private set; } = new ObservableCollection<string>();
    }
}
