using MusicStore.Models;
using MusicStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DataAccess
{
    public interface IAlbumRepository
    {
        List<Album> GetList(int? id);
        Album GetById(int id);
        void Add(Album album);
        void Delete(int p);
        void Update(Album album);
    }

    public class AlbumRepository : IAlbumRepository
    {
        public void Add(Album album)
        {
            AlbumService.Add(album);
        }

        public void Delete(int p)
        {
            AlbumService.Delete(p);
        }

        public Album GetById(int id)
        {
            return AlbumService.FindAlbumById(id);
        }

        public List<Album> GetList(int? id)
        {
            return AlbumService.GetList(id);
        }

        public void Update(Album album)
        {
            AlbumService.Update(album);
        }
    }
}
