using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    internal class Build
    {
        private readonly Logger _logger;
        private static int Id = 0;
        private int _number;
        private int _floorCount;
        private double _height;
        private int _apartmentCount;
        private int _entranceCount;

        public Build()
        {
            this.NextId();
            _number = Id;
        }

        public int Number
        {
            get { return _number; }

            set
            {
                if (value < 0)
                    _logger.IncorrectValue();
                else
                {
                    Number = value;
                    Id = value;
                }
            }
        }

        public int FloorCount
        {
            get { return _floorCount; }

            set
            {
                if (value < 0)
                    _logger.IncorrectValue();
                else _floorCount = value;
            }
        }

        public double Height
        {
            get { return _height; }

            set
            {
                if (value < 0)
                    _logger.IncorrectValue();
                else _height = value;
            }
        }


        public int ApartmentCount
        {
            get { return _apartmentCount; }

            set
            {
                if (value < 0)
                    _logger.IncorrectValue();
                else _apartmentCount = value;
            }
        }

        public int EntranceCount
        {
            get { return _entranceCount; }

            set
            {
                if (value < 0)
                    _logger.IncorrectValue();
                else _entranceCount = value;
            }
        }

        public double FloorHeight()
        {
            return (_height / _floorCount);
        }

        public int ApartmentPerEntrance()
        {
            return (_apartmentCount / _entranceCount);
        }

        public int ApartmentPerFloor()
        {
            return (_apartmentCount / _floorCount / _entranceCount);
        }

        private void NextId()
        {
            int id = Id + 1;
            Id = id;
        }
    }
}
