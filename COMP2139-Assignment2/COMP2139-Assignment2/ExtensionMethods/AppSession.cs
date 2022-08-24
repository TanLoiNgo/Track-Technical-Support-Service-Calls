using System;
using COMP2139_Assignment1.Models;
using Microsoft.AspNetCore.Http;

namespace COMP2139_Assignment1.ExtensionMethods
{
    public class AppSession
    {
        private const string customerKey = "customerId";

        private const string technicianKey = "technicianId";

        private ISession session { get; set; }
        public AppSession(ISession session)
        {
            this.session = session;
        }

        public void SetCustomer(int id)
        {
            session.SetInt32(customerKey, id);
        }

        public void SetTechnician(int id)
        {
            session.SetInt32(technicianKey, id);
        }

        public int GetCustomerId() => session.GetInt32(customerKey) ?? 0;

        public int GetTechnicianId() => session.GetInt32(technicianKey) ?? 0;

        public void RemoveCustomer()
        {
            session.Remove(customerKey);
        }

        public void RemoveTechnician()
        {
            session.Remove(technicianKey);
        }
    }
}
