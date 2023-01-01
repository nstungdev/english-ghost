using EnglishGhost.Business.Forms;
using EnglishGhost.Business.Services;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace EnglishGhost.GUI.Modules.Vocabularies
{
    /// <summary>
    /// Interaction logic for EditVocabularyForm.xaml
    /// </summary>
    public partial class EditVocabularyForm : Window
    {
        private readonly VocabularyService _vocabularyService;
        public EditVocabularyForm()
        {
            _vocabularyService = new VocabularyService();
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var form = new VocabularyForm
            {
                Mean = inpMean.Text,
                Note = inpNote.Text,
                Pronounce = inpPronounce.Text,
                Type = inpWordType.Text,
                Word = inpWord.Text
            };

            try
            {
                await _vocabularyService.CreateOneAsync(form);
                MessageBox.Show("Tạo mới thành công");
                var result = await _vocabularyService.GetAll();
                txtCounter.Text = $"Đã có {result.Count()} từ trong từ điển";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo mới thất bại " + ex.Message);
            }
        }
    }
}
