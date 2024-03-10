/// <summary>
/// This queue is circular.  When people are added via add_person, then they are added to the 
/// back of the queue (per FIFO rules).  When get_next_person is called, the next person
/// in the queue is displayed and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue {
    private readonly Queue<(string Name, int Turns)> _people = new();

    public int Length => _people.Count;

    /// <summary>
    /// Add new people to the queue with a name and number of turns.
    /// </summary>
    /// <param name="name">Name of the person.</param>
    /// <param name="turns">Number of turns remaining; 0 or less for infinite turns.</param>
    public void AddPerson(string name, int turns) {
        _people.Enqueue((name, turns));
    }

    /// <summary>
    /// Get the next person in the queue and display them.
    /// Re-enqueues them unless they have no more turns left.
    /// </summary>
    public void GetNextPerson() {
        if (_people.Count == 0) {
            Console.WriteLine("No one in the queue.");
            return;
        }

        var (Name, Turns) = _people.Dequeue();
        Console.WriteLine(Name);

        if (Turns > 1 || Turns <= 0) { // If more than 1 turn left, or infinite turns, decrement if not infinite.
            _people.Enqueue((Name, Turns > 0 ? Turns - 1 : Turns));
        }
    }

    public override string ToString() {
        // Representation of the queue's state as a string.
        var peopleDescriptions = new List<string>();
        foreach (var person in _people) {
            peopleDescriptions.Add($"{person.Name} ({(person.Turns <= 0 ? "∞" : person.Turns.ToString())} turns)");
        }
        return string.Join(", ", peopleDescriptions);
    }
}