using System.Text.Json.Serialization.Metadata;
using AppShip.ActionClass.Account;
using AppShip.ActionClass.HelperClass.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace AppShip.Interface
{
    public interface IUser
    {
        public List<ClientsDTO> GetClients();
        public List<ClientsDTO> GetClient(int id);
        public List<string> AddAccount(AccountCreate acount);
        public List<string> UpdateClient(int id, ClientsDTO client);
        public List<string> DeleteClient(int id);
        
    }
}
