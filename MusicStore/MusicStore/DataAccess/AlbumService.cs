using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Service
{
    public class AlbumService
    {
        public static List<Album> GetList(int? id)
        {
            var listAlbum = new List<Album>();
            try
            {
                using (var context = new PRN221_ProjectFinalContext())
                {
                    if (id != null)
                    {
                        listAlbum = context.Albums.Where(x => x.AlbumId == id).ToList();
                    }
                    else
                    {
                        listAlbum = context.Albums.ToList();
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("List album fail" + e.Message);
            }
            return listAlbum;
        }
        public static Album FindAlbumById(int id)
        {
            var Album = new Album();
            try
            {
                using (var context = new PRN221_ProjectFinalContext())
                {
                    Album = context.Albums.SingleOrDefault(x => x.AlbumId == id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("FindAlbumById fail" + e.Message);
            }
            return Album;
        }
        public static void Add(Album p)
        {
            try
            {
                using (var context = new PRN221_ProjectFinalContext())
                {
                    context.Albums.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Fail " + e.Message);
            }
        }
        public static void Update(Album p)
        {
            try
            {
                using (var context = new PRN221_ProjectFinalContext())
                {
                    var existingAlbum = context.Albums.SingleOrDefault(x => x.AlbumId== p.AlbumId);
                    if (existingAlbum != null)
                    {
                        context.Entry(existingAlbum).CurrentValues.SetValues(p);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Update Fail " + e.Message);
            }
        }
        public static void Delete(int p)
        {
            try
            {
                using (var context = new PRN221_ProjectFinalContext())
                {
                    var Album = context.Albums.FirstOrDefault(x => x.AlbumId == p);
                    if (Album != null)
                    {
                        context.Albums.Remove(Album);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete Fail " + e.Message);
            }
        }
    }
}
