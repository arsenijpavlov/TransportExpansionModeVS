using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace transportexpansion
{
    class Main : ModSystem
    {
        public override bool ShouldLoad(EnumAppSide forSide)
        {
            return true;
        }

        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            api.RegisterEntity("EntityAnimalBot", typeof(EntityAnimalBot));
        }
    }

    class FollowingBehaviour : EntityBehavior
    {
        public FollowingBehaviour(Entity entity) : base(entity)
        {
        }

        public override string PropertyName()
        {
            throw new NotImplementedException();
        }
    }
}
