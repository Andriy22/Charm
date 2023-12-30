public interface IStunable
{
    bool Stunned { get; }

    void Stun(float time);
}