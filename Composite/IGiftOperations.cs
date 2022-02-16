namespace Composite
{ // Structural. Compose object into a tree structure, and then work with that structure as if it is a single object. Consists of three parts; component (interface with operations), leaf, composite (many leaves. Communicates not via its leaves but via component) and finally client.
    public interface IGiftOperations // The composite object will implement this interface, but the leaf won't
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }
}
