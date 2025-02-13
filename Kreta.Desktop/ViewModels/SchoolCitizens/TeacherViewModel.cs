using CommunityToolkit.Mvvm.ComponentModel;
using Kreta.Desktop.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using Kreta.HttpService.Services;
using Kreta.Shared.Models.Entites;
using System.Collections.Generic;
using Kreta.Shared.Models.Entites.SchoolCitizens;


namespace Kreta.Desktop.ViewModels.SchoolCitizens
{
    public partial class TeacherViewModel : BaseViewModel
    {
        private readonly ITeacherHttpService _httpService;

        [ObservableProperty]
        private ObservableCollection<Teacher> _teacher = new ObservableCollection<Teacher>();
        public TeacherViewModel()
        {

        }
        public TeacherViewModel(ITeacherHttpService? httpService)
        {
            _httpService= httpService ?? throw new ArgumentNullException(nameof(httpService));
        }
     


        public override async Task InitializeAsync()
        {
            await UpdateViewAsync();
            await base.InitializeAsync();
        }

        private async Task UpdateViewAsync()
        {
            throw new NotImplementedException();
            List<Teacher> subjects = await _httpService.GetAllAsync();
        }

    }
}
