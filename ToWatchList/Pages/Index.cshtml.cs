using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToWatchList.Interfaces;
using ToWatchList.Services;

namespace ToWatchList.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string InputText { get; set; }
        public string OutputText { get; set; }

        private readonly string demoKey = "demo-key";
        private readonly IDatabaseStorage Database;

        public IndexModel()
        {
            Database = DatabaseStorageFactory.GetDatabaseStorage();
        }

        public async Task OnPostGetString()
        {
            OutputText = $"Value retrived: {await Database.GetAsync(demoKey)}";
        }

        public async Task OnPostSetString()
        {
            var res = await Database.SetAsync(demoKey, InputText);
            OutputText = $"Value set For key: {demoKey}";
        }
    }
}