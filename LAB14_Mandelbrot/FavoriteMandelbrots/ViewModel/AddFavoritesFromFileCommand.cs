using FavoriteMandelbrots.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Windows.Storage;

namespace FavoriteMandelbrots.ViewModel
{
    public class AddFavoritesFromFileCommand : CommandBase
    {
        private readonly Action<Area> addAction;

        public AddFavoritesFromFileCommand(MainViewerViewModel vm, Action<Area> addAction)
            : base(vm)
        {
            this.addAction = addAction;
        }

        public async override void Execute(object parameter)
        {
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".xml");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                using (StreamReader reader = new StreamReader(await file.OpenStreamForReadAsync()))
                {
                    XElement treeRoot = XElement.Load(reader);
                    ReadXmlTree(treeRoot);
                }
            }
        }

        private void ReadXmlTree(XElement root)
        {
            // EVIP: creating Xml using Linq to Xml
            foreach (var element in root.Elements())
            {
                Area model = new Area();
                model.Top = double.Parse(element.Attribute("top").Value);
                model.Bottom = double.Parse(element.Attribute("bottom").Value);
                model.Right = double.Parse(element.Attribute("right").Value);
                model.Left = double.Parse(element.Attribute("left").Value);
                
                vm.Favorites.Add(new AreaViewModel(model, vm));
                model.NotifyAllPropertiesChanged();
            }
        }
    }
}