using System;

namespace Promethean.Core
{
    public class RoomRenderers
    {
        private static volatile RoomRenderers _instance = null;
        private static readonly object _lock = new object();
        private RoomRenderers() { }

        public static RoomRenderers Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RoomRenderers();
                        }
                    }
                }
                return _instance;
            }
        }

        public IRoomRenderer this[RoomType roomType]
        {
            get
            {
                switch (roomType)
                {
                    case RoomType.Square:
                    case RoomType.Rectangle:
                        return DefaultRenderer;

                    case RoomType.Cross:
                        return CrossRenderer;

                    case RoomType.Diamond:
                        return DiamondRenderer;

                    default:
                        throw new NotImplementedException($"Room renderer {roomType} not implemented");
                }
            }
        }

        public IRoomRenderer CrossRenderer = new CrossRenderer();
        public IRoomRenderer DefaultRenderer = new DefaultRenderer();
        public IRoomRenderer DiamondRenderer = new DiamondRenderer();
    }
}