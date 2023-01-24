using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VO_BuildBuilder
{
    
    public partial class Form1 : Form
    {
        public Build result = new Build();
        public Build ancient = new Build { clever = 1, oratory = 3, wisdom = 3, lie = 2, learning = -1, agility = -3, energy = -3, endurance = -2, strength = -3, speed = -3, hardy = -2 };
        public Build old = new Build { clever = 1, oratory = 2, wisdom = 2, lie = 2, learning = -1, agility = -2, energy = -2, endurance = -1, strength = -2, speed = -2, imunity = 1, hardy = -1 };
        public Build elder = new Build { clever = 1, oratory = 2, wisdom = 2, lie=2, learning=0, energy = -1, endurance = 0, strength = 0, imunity = 2 };
        public Build adult = new Build { clever = 2, oratory = 1, wisdom = 1, lie=1, learning=1, energy = 0, endurance = 1, strength = 1, imunity=2 };
        public Build young = new Build { clever = 1, oratory = 1, learning=1, energy = 1, endurance = 1, strength = 1, speed = 1, agility = 1, imunity=1 };
        public Build teenager = new Build { clever = 0, oratory=0, learning=2, wisdom = -1, energy = 2, endurance = 2, strength = 1, speed=2, agility = 2, ironWill = -1 };
        
        public Build beygar = new Build { clever = 1, energy = 1, endurance = 1, strength = 1, noWeapons=1, navigation=1, hardy=1, speed = 1, agility = 1, hunting = 1, trading = 1, ironWill=1, metalwork=1, plant=1, medicine=1, cooking=1 };
        public Build hergand = new Build { wisdom = 1, trading = 2, lie = 1, building = 1, riding = 1, oratory=1, imunity = 1, cooking=2 };
        
        public Build druid = new Build { wisdom = 2, lie = 1, oratory=2, imunity = 2, polearm=2, khifes=1, agility=1, hunting=1, learning=1, alchemy=2, medicine=2, plant=2, hardy=2, antiToxin=1, ironWill=1, cooking=2 };
        
        public Build wolfBerserker = new Build { oneHanded=3, shields=3, stealth=2, agility=3, speed=2, strength=1, noWeapons=2, tactic=1, endurance=1, imunity=1, hardy=2, energy=1, trading=1, ironWill=2, hunting=1};
        public Build boarBerserker = new Build { oneHanded = 3, throwing = 3, stealth = 1, agility = 2, speed = 3, strength = 2, noWeapons = 2, endurance = 2, imunity = 2, hardy = 2, energy = 1, ironWill = 2, hunting = 2, antiToxin=3, alchemy=2, plant=2, medicine=2 };
        public Build bearBerserker = new Build { twoHanded=3, agility = 2, speed = 2, strength = 4, noWeapons = 3, endurance = 4, imunity = 1, hardy = 3, energy = 2, trading = 1, ironWill = 3 };
        
        public Build marsPriest;
        public Build jupiterPriest;
        
        public Build dianaPriest;
        public Build marsPaladin;
        public Build jupiterPaladin;
        public Build dianaPaladin;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrintBuild();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if(trackBar1.Value>=60)
            {
                label3.Text = trackBar1.Value + " - Древній";

            }
            else if(trackBar1.Value>=50)
            {
                label3.Text = trackBar1.Value + " - Старий";
            }
            else if (trackBar1.Value >= 40)
            {
                label3.Text = trackBar1.Value + " - Літній";
            }
            else if (trackBar1.Value >= 30)
            {
                label3.Text = trackBar1.Value + " - Зрілий";
            }
            else if (trackBar1.Value >= 20)
            {
                label3.Text = trackBar1.Value + " - Молодий";
            }
            else if (trackBar1.Value >= 15)
            {
                label3.Text = trackBar1.Value + " - Підліток";
            }
            PrintBuild();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox2.Text="";
            comboBox3.Text="";
            comboBox4.Text="";
            

            if (comboBox1.SelectedItem.ToString()=="Бейгар")
            {
                comboBox2.Items.AddRange(new string[] { "Звичайний", "Берсерк", "Друїд" });
                comboBox2.SelectedItem = "Звичайний";
            }
            else if (comboBox1.SelectedItem.ToString() == "Херганд")
            {
                comboBox2.Items.AddRange(new string[] { "Звичайний", "Паладін", "Жрець" });
                comboBox2.SelectedItem = "Звичайний";
            }
            PrintBuild();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox3.Text = "";
            comboBox4.Text = "";

            if (comboBox2.SelectedItem.ToString() == "Берсерк")
            {
                comboBox3.Items.AddRange(new string[] { "Вовк", "Кабан", "Ведмідь" });
                comboBox3.SelectedItem = "Вовк";
            }
            if (comboBox2.SelectedItem.ToString() == "Жрець")
            {
                comboBox3.Items.AddRange(new string[] { "Юпітер", "Марс", "Діана" });
                comboBox3.SelectedItem = "Юпітер";
            }
            if (comboBox2.SelectedItem.ToString() == "Паладін")
            {
                comboBox3.Items.AddRange(new string[] { "Орден Чистого Світила", "Орден Преторіонів", "Орден Якуба Доброго" });
                comboBox4.Items.AddRange(new string[] { "Юпітер", "Марс", "Діана" });
                comboBox3.SelectedItem = "Орден Чистого Світила";
                comboBox4.SelectedItem = "Юпітер";
            }
            PrintBuild();
        }
        private void PrintBuild()
        {
            result = new Build();

            if(trackBar1.Value>=60)
            {
                result = result + ancient;
            }
            else if (trackBar1.Value >= 50)
            {
                result = result + old;
            }
            else if (trackBar1.Value >= 40)
            {
                result = result + elder;
            }
            else if (trackBar1.Value >= 30)
            {
                result = result + adult;
            }
            else if (trackBar1.Value >= 20)
            {
                result = result + young;
            }
            else if (trackBar1.Value >= 15)
            {
                result = result + teenager;
            }

            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "Бейгар")
                {
                    result = result + beygar;
                }
                else if (comboBox1.SelectedItem.ToString() == "Херганд")
                {
                    result = result + hergand;
                }
            }
            if (comboBox2.SelectedItem != null)
            { 
                if (comboBox2.SelectedItem.ToString() == "Друїд")
                {
                    result = result + druid;
                }
            }
            if (comboBox3.SelectedItem != null) 
            { 
                if (comboBox3.SelectedItem.ToString() == "Вовк")
                {
                    result = result + wolfBerserker;
                }
                else if (comboBox3.SelectedItem.ToString() == "Кабан")
                {
                    result = result + boarBerserker;
                }
                else if (comboBox3.SelectedItem.ToString() == "Ведмідь")
                {
                    result = result + bearBerserker;
                }
            }

            result.ValidateBuild();

            OneHandedValue.Text = result.oneHanded.ToString();
            TwoHandedValue.Text = result.twoHanded.ToString();
            PolearmValue.Text = result.polearm.ToString();
            BowValue.Text = result.bow.ToString();
            CrossbowValue.Text = result.crossbow.ToString();
            ThrowingValue.Text = result.throwing.ToString();
            KnifesValue.Text = result.khifes.ToString();
            ShieldsValue.Text = result.shields.ToString();
            NoWeaponValue.Text = result.noWeapons.ToString();
            StealthValue.Text = result.stealth.ToString();
            SpeedValue.Text = result.speed.ToString();
            AgilityValue.Text = result.agility.ToString();
            RidingValue.Text = result.riding.ToString();
            TacticValue.Text = result.tactic.ToString();
            HuntingValue.Text = result.hunting.ToString();
            WisdomValue.Text = result.wisdom.ToString();
            CleverValue.Text = result.clever.ToString();
            CookingValue.Text = result.cooking.ToString();
            TamingValue.Text = result.taming.ToString();
            PlantsValue.Text = result.plant.ToString();
            MedicineValue.Text = result.medicine.ToString();
            AlchemyValue.Text = result.alchemy.ToString();
            LearningValue.Text = result.learning.ToString();
            MetalworkValue.Text = result.metalwork.ToString();
            BuildingValue.Text = result.building.ToString();
            EnduranceValue.Text = result.endurance.ToString();
            ImunityValue.Text = result.imunity.ToString();
            HardyValue.Text = result.hardy.ToString();
            EnergyValue.Text = result.energy.ToString();
            AntiToxineValue.Text = result.antiToxin.ToString();
            StrengthValue.Text = result.strength.ToString();
            TradingValue.Text = result.trading.ToString();
            NavigationValue.Text = result.navigation.ToString();
            IronWillingValue.Text = result.ironWill.ToString();
            OratoryValue.Text = result.oratory.ToString();
            LieValue.Text = result.lie.ToString();
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            PrintBuild();
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            PrintBuild();
        }
    }
    public class Build
    {
        public int oneHanded;
        public int twoHanded;
        public int polearm;
        public int bow;
        public int crossbow;
        public int throwing;
        public int khifes;
        public int shields;
        public int noWeapons;
        public int stealth;
        public int speed;
        public int agility;
        public int riding;
        public int tactic;
        public int hunting;
        public int wisdom;
        public int clever;
        public int cooking;
        public int taming;
        public int plant;
        public int medicine;
        public int alchemy;
        public int learning;
        public int metalwork;
        public int building;
        public int endurance;
        public int imunity;
        public int hardy;
        public int energy;
        public int antiToxin;
        public int strength;
        public int trading;
        public int navigation;
        public int ironWill;
        public int oratory;
        public int lie;

        public void ValidateBuild()
        {
            if (agility > 4)
            {
                agility = 4;
            }
            if (alchemy > 4)
            {
                alchemy = 4;
            }
            if (antiToxin > 4)
            {
                antiToxin = 4;
            }
            if (bow > 4)
            {
                bow = 4;
            }
            if (building > 4)
            {
                building = 4;
            }
            if (clever > 4)
            {
                clever = 4;
            }
            if (cooking > 4)
            {
                cooking = 4;
            }
            if (crossbow > 4)
            {
                crossbow = 4;
            }
            if (endurance > 4)
            {
                endurance = 4;
            }
            if (energy > 4)
            {
                energy = 4;
            }
            if (hardy > 4)
            {
                hardy = 4;
            }
            if (hunting > 4)
            {
                hunting = 4;
            }
            if (imunity > 4)
            {
                imunity = 4;
            }
            if (ironWill > 4)
            {
                ironWill = 4;
            }
            if (khifes > 4)
            {
                khifes = 4;
            }
            if (learning > 4)
            {
                learning = 4;
            }
            if (lie > 4)
            {
                lie = 4;
            }
            if (medicine > 4)
            {
                medicine = 4;
            }
            if (metalwork > 4)
            {
                metalwork = 4;
            }
            if (navigation > 4)
            {
                navigation = 4;
            }
            if (noWeapons > 4)
            {
                noWeapons = 4;
            }
            if (oneHanded > 4)
            {
                oneHanded = 4;
            }
            if (oratory > 4)
            {
                oratory = 4;
            }
            if (plant > 4)
            {
                plant = 4;
            }
            if (polearm > 4)
            {
                polearm = 4;
            }
            if (riding > 4)
            {
                riding = 4;
            }
            if (shields > 4)
            {
                shields = 4;
            }
            if (speed > 4)
            {
                speed = 4;
            }
            if (stealth > 4)
            {
                stealth = 4;
            }
            if (strength > 4)
            {
                strength = 4;
            }
            if (tactic > 4)
            {
                tactic = 4;
            }
            if (taming > 4)
            {
                taming = 4;
            }
            if (throwing > 4)
            {
                throwing = 4;
            }
            if (trading > 4)
            {
                trading = 4;
            }
            if (twoHanded > 4)
            {
                twoHanded = 4;
            }
            if (wisdom > 4)
            {
                wisdom = 4;
            }

            if (agility < 0)
            {
                agility = 0;
            }
            if (alchemy < 0)
            {
                alchemy = 0;
            }
            if (antiToxin < 0)
            {
                antiToxin = 0;
            }
            if (bow < 0)
            {
                bow = 0;
            }
            if (building < 0)
            {
                building = 0;
            }
            if (clever < 0)
            {
                clever = 0;
            }
            if (cooking < 0)
            {
                cooking = 0;
            }
            if (crossbow < 0)
            {
                crossbow = 0;
            }
            if (endurance < 0)
            {
                endurance = 0;
            }
            if (energy < 0)
            {
                energy = 0;
            }
            if (hardy < 0)
            {
                hardy = 0;
            }
            if (hunting < 0)
            {
                hunting = 0;
            }
            if (imunity < 0)
            {
                imunity = 0;
            }
            if (ironWill < 0)
            {
                ironWill = 0;
            }
            if (khifes < 0)
            {
                khifes = 0;
            }
            if (learning < 0)
            {
                learning = 0;
            }
            if (lie < 0)
            {
                lie = 0;
            }
            if (medicine < 0)
            {
                medicine = 0;
            }
            if (metalwork < 0)
            {
                metalwork = 0;
            }
            if (navigation < 0)
            {
                navigation = 0;
            }
            if (noWeapons < 0)
            {
                noWeapons = 0;
            }
            if (oneHanded < 0)
            {
                oneHanded = 0;
            }
            if (oratory < 0)
            {
                oratory = 0;
            }
            if (plant < 0)
            {
                plant = 0;
            }
            if (polearm < 0)
            {
                polearm = 0;
            }
            if (riding < 0)
            {
                riding = 0;
            }
            if (shields < 0)
            {
                shields = 0;
            }
            if (speed < 0)
            {
                speed = 0;
            }
            if (stealth < 0)
            {
                stealth = 0;
            }
            if (strength < 0)
            {
                strength = 0;
            }
            if (tactic < 0)
            {
                tactic = 0;
            }
            if (taming < 0)
            {
                taming = 0;
            }
            if (throwing < 0)
            {
                throwing = 0;
            }
            if (trading < 0)
            {
                trading = 0;
            }
            if (twoHanded < 0)
            {
                twoHanded = 0;
            }
            if (wisdom < 0)
            {
                wisdom = 0;
            }

        }
        public static Build operator +(Build b1, Build b2)
        {
            return new Build {
                agility = b1.agility + b2.agility,
                alchemy = b1.alchemy + b2.alchemy,
                antiToxin = b1.antiToxin + b2.antiToxin,
                bow = b1.bow + b2.bow,
                building = b1.building + b2.building,
                clever = b1.clever + b2.clever,
                cooking = b1.cooking + b2.cooking,
                crossbow = b1.crossbow + b2.crossbow,
                endurance = b1.endurance + b2.endurance,
                energy = b1.energy + b2.energy,
                hardy = b1.hardy + b2.hardy,
                hunting = b1.hunting + b2.hunting,
                imunity = b1.imunity + b2.imunity,
                ironWill = b1.ironWill + b2.ironWill,
                khifes = b1.khifes + b2.khifes,
                learning = b1.learning + b2.learning,
                lie = b1.lie + b2.lie,
                medicine = b1.medicine +b2.medicine,
                metalwork = b1.metalwork+b2.metalwork,
                navigation = b1.navigation+b2.navigation,
                noWeapons = b1.noWeapons+b2.noWeapons,
                oneHanded = b1.oneHanded+b2.oneHanded,
                oratory = b1.oratory+b2.oratory,
                plant = b1.plant+b2.plant,
                polearm = b1.polearm+b2.polearm,
                riding = b1.riding+b2.riding,
                shields = b1.shields+b2.shields,
                speed = b1.speed+b2.speed,
                stealth = b1.stealth+b2.stealth,
                strength = b1.strength+b2.strength,
                tactic = b1.tactic+b2.tactic,
                taming = b1.taming+b2.taming,
                throwing = b1.throwing+b2.throwing,
                trading = b1.trading+b2.trading,
                twoHanded = b1.twoHanded+b2.twoHanded,
                wisdom = b1.wisdom+b2.wisdom, 
            };
        }

    }
}
