using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tiles_ClickCheck {
    public class ContentManager {
        private Dictionary<int, object> content = new Dictionary<int, object>();

        private struct ContentDescriptor {
            public int contentId;
            public string contentName;
            public string location;
        }

        public void Load(string contentListId) {
            List<object> contentList = GetContentList(contentListId);

            for (int i = 0; i < 5; i++) {
                if (!content.ContainsKey(i))
                    content.Add(i, GetTile(i));
            }
        }

        private List<object> GetContentList(string contentId) {
            return new List<object> {
                new Bitmap(1, 1),
                new Bitmap(".\\lightblue.png"),
                new Bitmap(".\\darkgreen.png"),
                new Bitmap(".\\red.png"),
                new Bitmap(".\\yellow64.png")
            };
        }

        public T Get<T>(int contentId) {
            return (T)content[contentId];
        }

        public void UnloadAll() {
            content = null;
        }

        private Image GetTile(int tileIndex) {
            switch (tileIndex) {
                case 0:
                    return new Bitmap(1, 1);
                case 1:
                    return new Bitmap(".\\lightblue.png");
                case 2:
                    return new Bitmap(".\\darkgreen.png");
                case 3:
                    return new Bitmap(".\\red.png");
                case 4:
                    return new Bitmap(".\\yellow64.png");
                default:
                    throw new NotImplementedException(tileIndex.ToString());
            }
        }
    }
}
