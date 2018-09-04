using System;
using System.Text;

namespace hashes
{
    public class GhostsTask :
        IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>,
        IMagic
    {
        byte[] content;
        Document document;
        Vector vector = new Vector(0, 0);
        Segment segment = new Segment(new Vector(1, 2), new Vector(3, 4));
        Cat cat = new Cat("CatName1", "CatBreed1", DateTime.Now);
        Robot robot = new Robot("#001");

        Document IFactory<Document>.Create() => document;

        Vector IFactory<Vector>.Create() => vector;

        Segment IFactory<Segment>.Create() => segment;

        Cat IFactory<Cat>.Create() => cat;

        Robot IFactory<Robot>.Create() => robot;

        public GhostsTask()
        { // создаём недосозданный документ ибо он зависит от поля content
            var encoding = Encoding.ASCII;
            content = encoding.GetBytes("Hello World");
            document = new Document("Unnamed1", encoding, content);
        }

        public void DoMagic()
        { // портим всё, до чего можем незаметно дотянуться
            for (var i = 0; i < content.Length; i++)
                ++content[i];
            vector.Add(new Vector(5, 6));
            segment.End.Add(new Vector(7, 8));
            cat.Rename("CatName2");
            Robot.BatteryCapacity /= 2;
        }
    }
}
