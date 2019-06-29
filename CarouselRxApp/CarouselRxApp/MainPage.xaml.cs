using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarouselRxApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class MainPageViewModel
    {
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>(Enumerable.Range(1, 10).Select(_ => new Item()));
    }

    public class Item
    {
        public ReactiveProperty<string> Message { get; }
        public AsyncReactiveCommand Command { get; }

        public Item()
        {
            Message = new ReactiveProperty<string>();
            Command = new AsyncReactiveCommand()
                .WithSubscribe(async () =>
                {
                    Message.Value = "処理中";
                    await Task.Delay(3000);
                    Message.Value = "処理完了";
                });
        }
    }
}
