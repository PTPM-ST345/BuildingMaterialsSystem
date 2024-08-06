using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace GUI
{
    public class ThuatToan
    {
        public ThuatToan ()
        {

        }
        private Random _random = new Random();

        public List<Schedule> Optimize(List<Schedule> initialSchedule, int iterations, double initialTemperature, double coolingRate, DateTime batDau, DateTime ketThuc)
        {
            var currentSolution = new List<Schedule>(initialSchedule);
            var bestSolution = new List<Schedule>(initialSchedule);
            double temperature = initialTemperature;

            while (temperature > 1)
            {
                var newSolution = GetNeighborSolution(currentSolution, batDau, ketThuc);
                var currentCost = CalculateCost(currentSolution);
                var newCost = CalculateCost(newSolution);

                if (AcceptanceProbability(currentCost, newCost, temperature) > _random.NextDouble())
                {
                    currentSolution = new List<Schedule>(newSolution);
                }

                if (CalculateCost(currentSolution) < CalculateCost(bestSolution))
                {
                    bestSolution = new List<Schedule>(currentSolution);
                }

                temperature *= coolingRate;
            }

            return bestSolution;
        }


        private List<Schedule> GetNeighborSolution(List<Schedule> currentSolution, DateTime batDau, DateTime ketThuc)
        {
            var newSolution = new List<Schedule>(currentSolution);
            int index = _random.Next(newSolution.Count);

            // Thay đổi ngày làm việc của một nhân viên để tạo giải pháp hàng xóm
            var schedule = newSolution[index];
            schedule.Date = GetRandomDate(batDau, ketThuc);

            return newSolution;
        }

        private DateTime GetRandomDate(DateTime start, DateTime end)
        {
            var range = (end - start).Days;
            return start.AddDays(_random.Next(range + 1)); // +1 để bao gồm ngày kết thúc
        }

        private double CalculateCost(List<Schedule> schedule)
        {
            // Ensure each day has exactly one employee working
            var groupedByDate = schedule.GroupBy(s => s.Date);
            int penalty = 0;
            foreach (var group in groupedByDate)
            {
                if (group.Count() > 1)
                {
                    penalty += group.Count() - 1; // Extra employees for the same day
                }
            }
            return penalty;
        }
        private double AcceptanceProbability(double currentCost, double newCost, double temperature)
        {
            if (newCost < currentCost)
            {
                return 1.0;
            }
            return Math.Exp((currentCost - newCost) / temperature);
        }

        public List<Schedule> ScheduleTasksForEmployees(List<NhanVien> nhanViens, DateTime batDau, DateTime ketThuc)
        {
            int soNgay = (ketThuc - batDau).Days + 1;
            var schedules = new List<Schedule>();

            // Tạo lịch trình ban đầu cho từng nhân viên
            foreach (var nv in nhanViens)
            {
                for (int i = 0; i < soNgay / nhanViens.Count; i++)
                {
                    var schedule = new Schedule
                    {
                        EmployeeId = nv.MaNV,
                        Date = batDau.AddDays(new Random().Next(soNgay))
                    };
                    schedules.Add(schedule);
                }
            }

            // Tinh toán lịch trình tối ưu
            var optimizedSchedules = Optimize(schedules, 1000, 1000, 0.95, batDau, ketThuc);

            // Trả về lịch trình đã sắp xếp
            return optimizedSchedules;
        }

    }
    public class Schedule
    {
        public string EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; } // You can define how to calculate cost
    }
}
