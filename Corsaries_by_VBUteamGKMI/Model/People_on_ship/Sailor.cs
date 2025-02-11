﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Corsaries_by_VBUteamGKMI.Model.People_on_ship
{
    public enum Sailor_type { Jung, Experienced, Sea_wolf }
   public class Sailor
    {
        public Sailor_type _sailor_Type  { get; set; }
        public string _name;// имя матроса
        public int _hp_boost { get; set; } // увеличение здоровья капитана
        public double _damag_boost { get; set; } // увеличение урона капитана
        public double _deff_boost { get; set; } // увеличение защиты капитана
        public double _dodge_boost { get; set; }// увеличение  уворота капитана
        public double _critical_boost { get; set; }// увеличение шанса крит удара капитана
        public int _food_consumption { get; set; } // количество потребляемой провизии
        public int _price { get; set; }// цена за матроса
        public int _count = 0; // доступное количество

        private Sailor()
        {

        }

        public Sailor(Sailor_type sailor_Type)
        {
            _sailor_Type = sailor_Type;
            switch (_sailor_Type)
            {
                case Sailor_type.Jung:
                    _name = "Юнга";
                    _hp_boost = 1;
                    _damag_boost = 0.3;
                    _deff_boost = 0.1;
                    _dodge_boost = 0.1;
                    _critical_boost = 0.15;
                    _price = 100;
                    _food_consumption = 1;
                    break;
                case Sailor_type.Experienced:
                    _name = "Бывалй";
                    _hp_boost = 2;
                    _damag_boost = 0.6;
                    _deff_boost = 0.2;
                    _dodge_boost = 0.2;
                    _critical_boost = 0.2;
                    _price = 300;
                    _food_consumption = 2;
                    break;
                case Sailor_type.Sea_wolf:
                    _name = "Морской волк";
                    _hp_boost = 3;
                    _damag_boost = 0.9;
                    _deff_boost = 0.3;
                    _dodge_boost = 0.3;
                    _critical_boost = 0.3;
                    _price = 900;
                    _food_consumption = 3;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{_sailor_Type},{_name},{_hp_boost},{_damag_boost},{_deff_boost},{_dodge_boost},{_critical_boost},{_food_consumption},{_price},{_count}";
        }

        public static Sailor FromString(string data)
        {
            Sailor sailor = new Sailor();
            sailor._sailor_Type = (Sailor_type)Enum.Parse(typeof(Sailor_type), data.Split(',')[0]);
            sailor._name = data.Split(',')[1];
            sailor._hp_boost = int.Parse(data.Split(',')[2]);
            sailor._damag_boost = double.Parse(data.Split(',')[3]);
            sailor._deff_boost = double.Parse(data.Split(',')[4]);
            sailor._dodge_boost = double.Parse(data.Split(',')[5]);
            sailor._critical_boost = double.Parse(data.Split(',')[6]);
            sailor._food_consumption = int.Parse(data.Split(',')[7]);
            sailor._price = int.Parse(data.Split(',')[8]);
            sailor._count = int.Parse(data.Split(',')[9]);
            return sailor;
        }
    }
}