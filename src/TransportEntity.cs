using System;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace transol.src
{
//TODO need repair
    class AnimalDrawn : EntityAnimalBot, IMountable
    {
        protected bool isFollowed = false;
        protected EntityAgent drivenFrom = null;

        public Vec3d MountPosition
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float? MountYaw
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string SuggestedAnimation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void OnInteract(EntityAgent byEntity, ItemSlot slot, Vec3d hitPosition, EnumInteractMode mode)
        {
            base.OnInteract(byEntity, slot, hitPosition, mode);

            if (!this.isFollowed)
            {
                this.isFollowed = true;
                this.drivenFrom = byEntity;
                //this.StopAnimation(null);
            }
            else
            {
                this.isFollowed = false;
                this.drivenFrom = null;
            }
        }

        public override void OnGameTick(float dt)
        {
            if (!this.isFollowed)
                base.OnGameTick(dt);
            else
            {
                double distance = this.Pos.DistanceTo(drivenFrom.ownPosRepulse);
                //base.OnGameTick(dt);
                if (distance > 3)
                {
                    pathTraverser.WalkTowards(drivenFrom.ownPosRepulse, 0.0265f, (float)distance, null, null);
                    if (!this.AnimManager.IsAnimationActive("walk"))
                    {
                        this.AnimManager.StartAnimation("walk");
                    }
                }
                else
                {
                    pathTraverser.Stop();
                    this.AnimManager.StopAnimation("walk");
                }
                pathTraverser.OnGameTick(dt);
                base.OnGameTick(dt);
            }
        }

        public void MountableToTreeAttributes(TreeAttribute tree)
        {
            throw new NotImplementedException();
        }

        public void DidUnmount(EntityAgent entityAgent)
        {
            throw new NotImplementedException();
        }

        public void DidMount(EntityAgent entityAgent)
        {
            throw new NotImplementedException();
        }
    }
}
