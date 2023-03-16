using System;
using System.Collections.Generic;
using System.Text;

namespace BT_canhan
{
    public class Campaign
    {
        public string campaignCode;
        public string campaignName;
        public int totalVolunteer;

        public Campaign(string code, string name)
        {
            campaignCode = code;
            campaignName = name;
            totalVolunteer = 0;
        }
    }

    public class Volunteer
    {
        public string volunteerCode;
        public string fullName;
        public int age;
        public int totalCampaigns;

        public Volunteer(string code, string name, int age)
        {
            volunteerCode = code;
            fullName = name;
            this.age = age;
            totalCampaigns = 0;
        }
    }

    public class VolunteerManager
    {
        private List<Campaign> campaigns;
        private List<Volunteer> volunteers;

        public VolunteerManager()
        {
            campaigns = new List<Campaign>();
            volunteers = new List<Volunteer>();
        }

        public void AddCampaign(Campaign campaign)
        {
            campaigns.Add(campaign);
        }

        public void AddVolunteer(Volunteer volunteer)
        {
            volunteers.Add(volunteer);
        }

        public List<Volunteer> GetTopVolunteers()
        {
            List<Volunteer> topVolunteers = new List<Volunteer>();
            int maxCampaigns = 0;

            foreach (Volunteer volunteer in volunteers)
            {
                if (volunteer.totalCampaigns > maxCampaigns)
                {
                    topVolunteers.Clear();
                    topVolunteers.Add(volunteer);
                    maxCampaigns = volunteer.totalCampaigns;
                }
                else if (volunteer.totalCampaigns == maxCampaigns)
                {
                    topVolunteers.Add(volunteer);
                }
            }
            return topVolunteers;
        }

        public List<Campaign> GetTopCampaigns()
        {
            List<Campaign> topCampaigns = new List<Campaign>();
            int maxVolunteers = 0;

            foreach (Campaign campaign in campaigns)
            {
                if (campaign.totalVolunteer > maxVolunteers)
                {
                    topCampaigns.Clear();
                    topCampaigns.Add(campaign);
                    maxVolunteers = campaign.totalVolunteer;
                }
                else if (campaign.totalVolunteer == maxVolunteers)
                {
                    topCampaigns.Add(campaign);
                }
            }

            return topCampaigns;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            VolunteerManager volunteerManager = new VolunteerManager();
            // Thêm các chiến dịch vào hệ thống
            Campaign campaign1 = new Campaign("C001", "Chiến dịch 1: Hỗ trợ người già neo đơn");
            Campaign campaign2 = new Campaign("C002", "Chiến dịch 2: Phân phát quà cho trẻ em mồ côi có thành tích học tập tốt");
            Campaign campaign3 = new Campaign("C003", "Chiến dịch 3: Góp quỹ cho trẻ em khuyết tật ");
            volunteerManager.AddCampaign(campaign1);
            volunteerManager.AddCampaign(campaign2);
            volunteerManager.AddCampaign(campaign3);

            // Thêm các sinh viên vào hệ thống
            Volunteer volunteer1 = new Volunteer("V001", "Nguyen Van A", 20);
            Volunteer volunteer2 = new Volunteer("V002", "Tran Thi B", 21);
            Volunteer volunteer3 = new Volunteer("V003", "Pham Van C", 22);
            Volunteer volunteer4 = new Volunteer("V004", "Le Thi D", 23);
            volunteerManager.AddVolunteer(volunteer1);
            volunteerManager.AddVolunteer(volunteer2);
            volunteerManager.AddVolunteer(volunteer3);
            volunteerManager.AddVolunteer(volunteer4);

            // Thêm thông tin chiến dịch cho các sinh viên
            volunteer1.totalCampaigns = 2;
            volunteer2.totalCampaigns = 1;
            volunteer3.totalCampaigns = 3;
            volunteer4.totalCampaigns = 2;

            // sinh viên có số lượng chiến dịch nhiều nhất
            List<Volunteer> topVolunteers = volunteerManager.GetTopVolunteers();
            Console.WriteLine("Top volunteers:");
            foreach (Volunteer volunteer in topVolunteers)
            {
                Console.WriteLine(volunteer.fullName + " (" + volunteer.age + " years old)");
            }

            // Các chiến dịch có số lượng sinh viên tham gia nhiều nhất
            List<Campaign> topCampaigns = volunteerManager.GetTopCampaigns();
            Console.WriteLine("Top campaigns: ");
            foreach (Campaign campaign in topCampaigns)
            {
                Console.WriteLine(campaign.campaignName);
            }
        }
    }
}