using MusicLib.BLL.DTO;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.BLL.Infrastructure;
using MusicLib.BLL.Interfaces;
using AutoMapper;

namespace MusicLib.BLL.Services
{
    public class VideoService : IVideoService
    {
        IUnitOfWork Database { get; set; }

        public VideoService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task CreateVideo(VideoDTO videoDto)
        {
            var video = new Video
            {
                Id = videoDto.Id,
                FileName = videoDto.FileName,
                Path = videoDto.Path
            };
            await Database.Videos.Create(video);

            await Database.Save();
        }

        public async Task UpdateVideo(VideoDTO videoDto)
        {
            var video = new Video
            {
                Id = videoDto.Id,
                FileName = videoDto.FileName,
                Path = videoDto.Path
            };
            Database.Videos.Update(video);

            await Database.Save();
        }

        public async Task DeleteVideo(int id)
        {
            try
            {
                await Database.Videos.Delete(id);
                
                await Database.Save();

            } catch (Exception ex)
            {

            }

        }

        public async Task<VideoDTO> GetVideo(int id)
        {
            var video = await Database.Videos.Get(id);

            if (video == null)
                throw new ValidationException("Wrong video!", "");

            return new VideoDTO
            {
                Id = video.Id,
                FileName = video.FileName,
                Path = video.Path
            };
        }

        // Automapper позволяет проецировать одну модель на другую, что позволяет сократить объемы кода и упростить программу.
        public async Task<IEnumerable<VideoDTO>> GetVideos()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Video, VideoDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Video>, IEnumerable<VideoDTO>>(await Database.Videos.GetAll());
        }
    }
}
