﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;

using Model;

namespace View
{
    /// <summary>
    /// Класс MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список объектов PassiveElementBase.
        /// </summary>
        private BindingList<PassiveElementBase> _data = new BindingList<PassiveElementBase>();
        
        /// <summary>
        /// Конструктор класса MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            dataGridPassiveElements.DataSource = _data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddObjectButtonClick(object sender, EventArgs e)
        {
            AddObjectForm addObjectForm = new AddObjectForm();
            addObjectForm.Show();
            addObjectForm.SendElement += AddElementEvent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddElementEvent(object sender, PassiveElementEventArgs e)
        {
            _data.Add(e.AddedElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteObjectButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridPassiveElements.SelectedRows.Count > 1)
                {
                    foreach(DataGridViewRow row in dataGridPassiveElements.SelectedRows)
                    {
                        dataGridPassiveElements.Rows.Remove(row);
                    }
                }
                else
                {
                    if (dataGridPassiveElements.CurrentCell == null)
                    {
                        throw new Exception("Не выбрано ни одной записи.");
                    }
                    _data.RemoveAt(dataGridPassiveElements.CurrentCell.RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindObjectButtonClick(object sender, EventArgs e)
        {
            FindObjectForm findObjectForm = new FindObjectForm(_data);
            findObjectForm.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDataButtonClick(object sender, EventArgs e)
        {
            if (_data.Count == 0)
            {
                MessageBox.Show("Отсутствуют данные для сохранения.", "Данные не сохранены", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<PassiveElementBase>));
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы (*.ldv)|*.ldv|Все файлы (*.*)|*.*",
                AddExtension = true,
                DefaultExt = ".ldv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string fileName = saveFileDialog.FileName;

            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                
                serializer.Serialize(fileStream, _data);
            }

            MessageBox.Show("Файл успешно сохранён.", "Сохранение завершено", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void LoadDataButtonClick(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<PassiveElementBase>));
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы (*.ldv)|*.ldv|Все файлы (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string fileName = openFileDialog.FileName;

            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    _data = (BindingList<PassiveElementBase>)serializer.Deserialize(fileStream);
                }
                dataGridPassiveElements.DataSource = _data;
                dataGridPassiveElements.CurrentCell = null;
                MessageBox.Show("Файл успешно загружен.", "Загрузка завершена",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Файл повреждён или не соответствует формату.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}