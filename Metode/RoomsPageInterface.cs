
using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace API_tests
{
    public class RoomsPageInterface
    {
        private string url;
        private string cookie;

        public RoomsPageInterface(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }

        public interface RoomActions
        {
            [Post("/games/create/")]
            Task<GameInfo> GetRoomInfo([Body(BodySerializationMethod.UrlEncoded)]RoomBody name, RoomBody cardSetType);


        }

        public interface NewRoomNameInterface
        {
            [Post("/games/edit/")]
            Task<GameInfo> GetRoomInfo([Body(BodySerializationMethod.UrlEncoded)]RoomBody name);
        }
        
        public interface DeleteRoom
        {
            [Delete("/games/delete")]
            Task  DeleteRoom([Body]int gameId);
        }

        // public interface CardType
        // {
        //     [Post("games/create/")]
        //     Task<GameInfo> GetRoomInfo([Body(BodySerializationMethod.UrlEncoded)]RoomBody name, RoomBody cardSetType);
        // }
        
    }
}