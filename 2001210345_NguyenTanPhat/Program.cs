using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2001210345_NguyenTanPhat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>
            {
                new Item { Value = 60, Weight = 10 },
                new Item { Value = 100, Weight = 20 },
                new Item { Value = 120, Weight = 30 }
            };

            int capacity = 50;

            double maxValue = GreedyKnapsack(capacity, items);
            Console.WriteLine("Maximum value in Knapsack = " + maxValue);
            Console.ReadLine();
        }
        public class Item
        {
            public int Value { get; set; }
            public int Weight { get; set; }
            public double Ratio { get { return (double)Value / Weight; } }
        }
        public static double GreedyKnapsack(int capacity, List<Item> items)
        {
            // Sắp xếp các mục theo tỷ lệ giá trị trên trọng lượng theo thứ tự giảm dần
            items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio));

            double totalValue = 0;
            int currentWeight = 0;

            foreach (var item in items)
            {
                if (currentWeight + item.Weight <= capacity)
                {
                    currentWeight += item.Weight;
                    totalValue += item.Value;
                }
                else
                {
                    int remainingWeight = capacity - currentWeight;
                    totalValue += item.Value * ((double)remainingWeight / item.Weight);
                    break;
                }
            }
            return totalValue;
        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _2001210345_NguyenTanPhat
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Phần của bài toán ba lô phân số
//            List<Item> items = new List<Item>
//            {
//                new Item { Value = 60, Weight = 10 },
//                new Item { Value = 100, Weight = 20 },
//                new Item { Value = 120, Weight = 30 }
//            };

//            int capacity = 50;

//            double maxValue = GreedyKnapsack(capacity, items);
//            Console.WriteLine("Maximum value in Knapsack = " + maxValue);

//            // Phần của bài toán chọn hoạt động
//            List<Activity> activities = new List<Activity>
//            {
//                new Activity { Start = 1, Finish = 4 },
//                new Activity { Start = 3, Finish = 5 },
//                new Activity { Start = 0, Finish = 6 },
//                new Activity { Start = 5, Finish = 7 },
//                new Activity { Start = 8, Finish = 9 }
//            };

//            List<Activity> selectedActivities = ActivitySelection(activities);
//            Console.WriteLine("Selected Activities:");
//            foreach (var activity in selectedActivities)
//            {
//                Console.WriteLine("Start: {0}, Finish: {1}", activity.Start, activity.Finish);

//            }
//            Console.ReadLine();
//        }

//        public class Item
//        {
//            public int Value { get; set; }
//            public int Weight { get; set; }
//            public double Ratio { get { return (double)Value / Weight; } }
//        }

//        public static double GreedyKnapsack(int capacity, List<Item> items)
//        {
//            // Sắp xếp các mục theo tỷ lệ giá trị trên trọng lượng theo thứ tự giảm dần
//            items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio));

//            double totalValue = 0;
//            int currentWeight = 0;

//            foreach (var item in items)
//            {
//                if (currentWeight + item.Weight <= capacity)
//                {
//                    currentWeight += item.Weight;
//                    totalValue += item.Value;
//                }
//                else
//                {
//                    int remainingWeight = capacity - currentWeight;
//                    totalValue += item.Value * ((double)remainingWeight / item.Weight);
//                    break;
//                }
//            }
//            return totalValue;
//        }

//        public class Activity
//        {
//            public int Start { get; set; }
//            public int Finish { get; set; }
//        }

//        public static List<Activity> ActivitySelection(List<Activity> activities)
//        {
//            // Sắp xếp các hoạt động theo thời gian kết thúc
//            activities.Sort((x, y) => x.Finish.CompareTo(y.Finish));

//            List<Activity> selectedActivities = new List<Activity>();
//            int lastFinishTime = 0;

//            foreach (var activity in activities)
//            {
//                if (activity.Start >= lastFinishTime)
//                {
//                    selectedActivities.Add(activity);
//                    lastFinishTime = activity.Finish;
//                }
//            }

//            return selectedActivities;
//        }
//    }
//}
