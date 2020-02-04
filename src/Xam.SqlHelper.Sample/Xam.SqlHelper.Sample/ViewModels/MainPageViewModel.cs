using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xam.SqlHelper.Sample.Models;
using Xam.SqlHelper.Sample.Repository;

namespace Xam.SqlHelper.Sample.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Properties

        private readonly ExampleItemRepository _repo;

        private string _sqlStatement;

        public string SqlStatement
        {
            get
            {
                return _sqlStatement;
            }
        }

        #endregion Properties

        public MainPageViewModel()
        {
            _repo = new ExampleItemRepository();

            _sqlStatement = _repo.LoadSql<ExampleItem>("AllExampleItemsSinceDate.sql", true, "ei", false);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}
