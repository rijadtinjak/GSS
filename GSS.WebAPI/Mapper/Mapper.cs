using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSS.WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.User, Model.User>();
            CreateMap<Database.User, Model.User>().ReverseMap();

            CreateMap<Database.City, Model.City>();
            CreateMap<Database.City, Model.City>().ReverseMap();

            CreateMap<Database.Country, Model.Country>();
            CreateMap<Database.Country, Model.Country>().ReverseMap();

            CreateMap<Database.Consensus, Model.Consensus>();
            CreateMap<Database.Consensus, Model.Consensus>().ReverseMap();

            CreateMap<Database.Manager, Model.Manager>();
            CreateMap<Database.Manager, Model.Manager>().ReverseMap();

            CreateMap<Database.Search, Model.Search>();
            CreateMap<Database.Search, Model.Search>().ReverseMap();

            CreateMap<Database.Segment, Model.Segment>();
            CreateMap<Database.Segment, Model.Segment>().ReverseMap();

            CreateMap<Database.SegmentSearchHistory, Model.SegmentSearchHistory>();
            CreateMap<Database.SegmentSearchHistory, Model.SegmentSearchHistory>().ReverseMap();

            CreateMap<Database.Zone, Model.Zone>();
            CreateMap<Database.Zone, Model.Zone>().ReverseMap();

            CreateMap<Database.Person, Model.Person>();
            CreateMap<Database.Person, Model.Person>().ReverseMap();

            CreateMap<Database.POSCumulativeArchiveEntry, Model.POSCumulativeArchiveEntry>();
            CreateMap<Database.POSCumulativeArchiveEntry, Model.POSCumulativeArchiveEntry>().ReverseMap();

            CreateMap<Database.SortedSegmentArchiveEntry, Model.SortedSegmentArchiveEntry>();
            CreateMap<Database.SortedSegmentArchiveEntry, Model.SortedSegmentArchiveEntry>().ReverseMap();

            CreateMap<Database.SegmentPoint, Model.SegmentPoint>();
            CreateMap<Database.SegmentPoint, Model.SegmentPoint>().ReverseMap();

        }
    }
}
