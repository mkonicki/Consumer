using System;

namespace RecruitmentApp.Entities
{
    public interface IEntity
    {
    }

    public interface IEntityWithGuidId : IEntity
    {
        Guid GetId();
    }

    public interface IEntityWithIntId : IEntity
    {
        int GetId();
    }
}