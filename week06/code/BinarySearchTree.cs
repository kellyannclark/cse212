using System.Collections;

public class BinarySearchTree : IEnumerable<int> {
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value) {
        // Create new node
        Node newNode = new Node(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_root is null)
            _root = newNode;
        // If the list is not empty, then only head will be affected.
        else
            _root.Insert(value);
    }

    /// <summary>
    /// Check to see if the tree contains a certain value
    /// </summary>
    /// <param name="value">The value to look for</param>
    /// <returns>true if found, otherwise false</returns>
    public bool Contains(int value) {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Yields all values in the tree
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() {
        // call the generic version of the method
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the BST
    /// </summary>
    public IEnumerator<int> GetEnumerator() {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers) {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values) {
        if (node is not null) {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Iterate backward through the BST.
    /// </summary>
    public IEnumerable Reverse() {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers) {
            yield return number;
        }
    }

private void TraverseBackward(Node? node, List<int> values) {
    if (node == null) {
        // If the node is null, there's nothing to add, so return immediately.
        return;
    }

    // Since we are traversing backwards, we start with the right subtree.
    // This ensures that we're adding the larger values first.
    TraverseBackward(node.Right, values);

    // After traversing the right subtree, we add the current node's value.
    // This will add the node's value after all of its right descendants have been added,
    // ensuring that larger values are added before the current node's value.
    values.Add(node.Data);

    // Finally, we traverse the left subtree.
    // This will add the smaller values after the current node's value,
    // ensuring that the values are added in descending order.
    TraverseBackward(node.Left, values);
}


    /// <summary>
    /// Get the height of the tree
    /// </summary>
    public int GetHeight() {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString() {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}