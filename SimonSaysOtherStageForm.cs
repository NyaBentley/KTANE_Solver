﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KTANE_Solver
{
    public partial class SimonSaysOtherStageForm : ModuleForm
    {
        SimonSays module;
        SimonSaysForm firstStage;
        int stage;

        public SimonSaysOtherStageForm(int stage, SimonSaysForm firstStage, SimonSays module, Bomb bomb, StreamWriter logFileWriter, ModuleSelectionForm moduleSelectionForm):base(bomb,logFileWriter,moduleSelectionForm)
        {
            InitializeComponent();
            this.firstStage = firstStage;
            UpdateForm(stage, module, bomb, logFileWriter, moduleSelectionForm);
        }

        public void UpdateForm(int stage, SimonSays module, Bomb bomb, StreamWriter logFileWriter, ModuleSelectionForm moduleSelectionForm)
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);
            this.module = module;
            this.stage = stage;
            stageLabel.Text = $"Stage {stage}";
            inputTextBox.Text = "";
        }

        private void moduleSelectionButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void backButton_Click(object sender, EventArgs e)
        {

            module.lights = module.lights.Remove(module.lights.Length-1);

            PrintDebugLine($"User pressed back. Sequence is now {module.lights}\n");


            if (stage == 2)
            {
                this.Hide();
                firstStage.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                firstStage.Show();
            }

            else
            {
                UpdateForm(stage - 1, module, Bomb, LogFileWriter, ModuleSelectionForm);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            firstStage.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            firstStage.Show();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike("Simon Says");
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            String input = inputTextBox.Text.ToUpper();

            //there can only be one char in the textbox
            if (input.Length != 1)
            {
                ShowErrorMessage("There can only be 1 character", "Simon Says Error");
                return;
            }

            //textbox can only contain the character b, r, g, or y
            switch (input[0])
            {
                case 'B':
                case 'G':
                case 'R':
                case 'Y':
                    break;

                default:
                    ShowErrorMessage("Textbox can only contain the character b, r, g, or y", "Simon Says Error");
                    return;

            }

            module.Solve(stage, input[0]);
            UpdateForm(stage + 1, module, Bomb, LogFileWriter, ModuleSelectionForm);
        }

        
    }
}
