﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Задание_2
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, params Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }
    }
}
