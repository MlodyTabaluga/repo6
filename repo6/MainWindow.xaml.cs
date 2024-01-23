using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace repo6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Album> Albums { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Albums = new ObservableCollection<Album>
            {
                new Album
                {
                    Name = "Vacation 2022",
                    Photos = new ObservableCollection<Photo>
                    {
                        new Photo { Image = "./Images/esa1.jpg", Caption = "Beautiful scenery" },
                        new Photo { Image = "./Images/esa2.jpg", Caption = "Family photo" },
                        new Photo { Image = "./Images/esa3.jpg", Caption = "Family photasdo" }
                        // Dodaj więcej zdjęć
                    }
                },
                // Dodaj więcej albumów

                new Album
                {
                    Name = "NIggas in Paris",
                    Photos = new ObservableCollection<Photo>
                    {
                        new Photo { Image = "./Images/esa2.jpg", Caption = "Family photo" },
                        new Photo { Image = "./Images/esa3.jpg", Caption = "Family photasdo" }
                    }

                },
            };

            albumsListBox.ItemsSource = Albums;
            albumsListBox.SelectionChanged += AlbumsListBox_SelectionChanged;
        }
        private void AlbumsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (albumsListBox.SelectedItem != null)
            {
                Album selectedAlbum = (Album)albumsListBox.SelectedItem;
                photosListView.ItemsSource = selectedAlbum.Photos;
            }
        }
        private void photosListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Photo photo = (Photo)photosListView.SelectedItem;
            Details details = new Details(photo);
            details.ShowDialog();
        }
    }
}
