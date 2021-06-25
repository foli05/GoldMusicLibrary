using GoldMusicLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GoldMusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> Sounds;
        private List<MenuItem> MenuItems;
        public MainPage()
        {
            this.InitializeComponent();
            Sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(Sounds);

            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Genre = GenreSelection.Country,
                    IconFile = "/Assets/icons/Country.png"
                },
                new MenuItem
                {
                    Genre = GenreSelection.Electronic,
                    IconFile = "/Assets/icons/electronic.png"
                },
                new MenuItem
                {
                    Genre = GenreSelection.Jazz,
                    IconFile = "/Assets/icons/jazz.png"
                },
                new MenuItem
                {
                    Genre = GenreSelection.RnB,
                    IconFile = "/Assets/icons/rnb.png"
                }
            };


        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.GetAllSounds(Sounds);
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MenuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = MenuItem.Genre.ToString();
            SoundManager.GetSoundsbyGenre(Sounds, MenuItem.Genre);
            BackButton.Visibility = Visibility.Visible;
        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, sound.MusicFile);
        }
    }
}
