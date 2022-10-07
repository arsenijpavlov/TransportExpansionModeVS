using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;

namespace transportexpansion.src
{
    class CartEntity : TransportEntity
    {
        protected bool isDriven;
        protected EntityAgent driveEntity;
        public PathTraverserBase pathTraverser;

        public CartEntity()
        {
            isDriven = false;
            driveEntity = null;
        }

        public override void Initialize(EntityProperties properties, ICoreAPI api, long InChunkIndex3d)
        {
            base.Initialize(properties, api, InChunkIndex3d);
            isDriven = false;
        }

        public override void OnInteract(EntityAgent byEntity, ItemSlot slot, Vec3d hitPosition, EnumInteractMode mode)
        {
            base.OnInteract(byEntity, slot, hitPosition, mode);
            if (isDriven)
            {
                isDriven = false;
                driveEntity = null;
            }
            else
            {
                isDriven = true;
                driveEntity = byEntity;
            }
        }

        public override void OnGameTick(float dt)
        {
            base.OnGameTick(dt);
            if(isDriven && driveEntity != null)
            {
                //this.controls.WalkVector.Add(driveEntity.Pos.XYZ);
                this.Controls.SetFrom(driveEntity.Controls);
            }
        }

        // понизить прочность механизма при падении
        public override void OnFallToGround(double motionY)
        {
            base.OnFallToGround(motionY);
        }

    }
}
