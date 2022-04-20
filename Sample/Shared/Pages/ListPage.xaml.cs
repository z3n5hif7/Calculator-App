using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;


namespace Sample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListPage : ContentPage
	{
        ObservableCollection<ToDoModel> toDoList = new ObservableCollection<ToDoModel>();
		public ListPage ()
		{
			InitializeComponent ();
            toDoListView.ItemsSource = toDoList;
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ToDoEntry.Text))
            {
                toDoList.Add(new ToDoModel() { id = toDoList.Count, text = ToDoEntry.Text, isDone = false });
                ToDoEntry.Text = string.Empty;
            }
            else
            {
                DisplayAlert("Error", "Cannot add empty entry to list", "Okay");
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            bool choice = await DisplayAlert("Delete Item", "Are you sure you want to delete this item?", "Yes","No");
            if (choice)
            {
                ToDoModel item = new ToDoModel();
                foreach(var i in toDoList){
                    if (i.id == Convert.ToInt32(btn.ClassId))
                        item = i;
                }
                toDoList.Remove(item);
                if (Device.RuntimePlatform == Device.Android)
                    DependencyService.Get<iToastService>().Show("Item deleted!", true);
            }
        }

        private void DoneButton_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            ToDoModel item = new ToDoModel();
            foreach (var i in toDoList)
            {
                if (i.id == Convert.ToInt32(btn.ClassId))
                {
                    i.isDone = !i.isDone;
                    if (Device.RuntimePlatform == Device.Android)
                        DependencyService.Get<iToastService>().Show(i.isDone ? "Item done!" : "Item undone!", false);

                }
            }
        }

        private void ItemEntry_Completed(object sender, EventArgs e)
        {
            Xamarin.Forms.Entry entry = sender as Xamarin.Forms.Entry;
            ToDoModel item = new ToDoModel();

            if (!string.IsNullOrEmpty(entry.Text))
            {
                foreach (var i in toDoList)
                {
                    if (i.id == Convert.ToInt32(entry.ClassId))
                        i.text = entry.Text;
                }
                if (Device.RuntimePlatform == Device.Android)
                    DependencyService.Get<iToastService>().Show("Item updated!", true);
            }
            else
            {
                DisplayAlert("Error", "Cannot update item if field is empty", "Okay");
            }
        }
    }
}