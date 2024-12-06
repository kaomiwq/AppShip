using System.Linq;
using AppShip.ActionClass.Account;
using AppShip.ActionClass.HelperClass.DTO;
using AppShip.Interface;
using AppShip.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppShip.ActionClass
{
    public class ClientClass : IUser
    {
        private readonly ShipShipContext _context;
        public ClientClass(ShipShipContext context)
        {
            _context = context;
        }

        public List<string> AddAccount(AccountCreate account)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(account.Name))
                    return new List<string> { "Поле Name не заполнено!" };
                if (account.Name.Length > 50)
                    return new List<string> { "Значение для поля Name должно входить диапазон до 50 символов!" };

                if (string.IsNullOrWhiteSpace(account.PhoneNumber))
                    return new List<string> { "Поле Name не заполнено!" };
                if (account.PhoneNumber.Length > 15)
                    return new List<string> { "Номер телефона не может быть такого размера!" };

                Client createClient = new Client()
                {
                    Name = account.Name,
                    PhoneNumber = account.PhoneNumber
                };

                _context.Clients.Add(createClient);
                _context.SaveChanges();

                int ClientId = createClient.Id;

                Results.Created();
                return [$"Пользователь успешно создан, ID - {ClientId}"];
            }
            catch (Exception) 
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                throw;
            }
        }

        public List<string> DeleteClient(int id)
        {
            try
            {
                var client = _context.Clients.Find(id);

                if (client == null)
                {
                    Results.NotFound(new List<string> { "Пользователь не найден!" });
                }

                var clientOrder = _context.Orders.Where(order => order.ClientId == id).ToList();

                if (clientOrder.Any())
                {
                    _context.RemoveRange(clientOrder);
                    _context.SaveChanges();
                }

                _context.Clients.Remove(client);
                _context.SaveChanges();

                Results.NoContent();
                return ["Пользователь успешно удален!"];
            }
            catch (Exception) 
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                throw;
            }
        }

        public List<ClientsDTO> GetClient(int id)
        {
            try 
            {
                var client = _context.Clients.Find(id);
                if (client == null) 
                {
                    Results.NotFound(new List<string> { "Пользователь с этим номером телефона не найден!" });
                }

                var data = _context.Clients.Where(ph => ph.Id == id).Select(
                x => new ClientsDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                }
                    ).ToList();
                return (List<ClientsDTO>)data;
            }
            catch (Exception)
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<ClientsDTO> GetClients()
        {
            try
            {
                var data = _context.Clients.Select(
                    x => new ClientsDTO()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        PhoneNumber = x.PhoneNumber,
                    }
                    ).ToList();
                return (List<ClientsDTO>)data;
            }
            catch (Exception) 
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<string> UpdateClient(int id, ClientsDTO client)
        {
            try
            {
                var userData = _context.Clients.FirstOrDefault(x => x.Id == id);

                if (userData == null)
                {
                    Results.NoContent();
                    return [];
                }

                userData.Name = client.Name;
                userData.PhoneNumber = client.PhoneNumber;

                _context.Clients.Update(userData);
                _context.SaveChanges();

                Results.Ok();
                return ["Данные пользователя успесно обновлены!"];
            }
            catch 
            {
                Results.BadRequest();
                throw;
            }
        }
    }
}
