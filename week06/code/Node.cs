public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
        // Check if the value to insert is less than the current node's value
        if (value < Data) {
            // Target position is to the left of the current node
            if (Left is null) {
                // If there's no left child, insert the new value here
                Left = new Node(value);
            } else {
                // If there's a left child, recursively attempt to insert into the left subtree
                Left.Insert(value);
            }
        } else if (value > Data) {
            // If the value is greater than the current node's value, target position is to the right
            if (Right is null) {
                // If there's no right child, insert the new value here
                Right = new Node(value);
            } else {
                // If there's a right child, recursively attempt to insert into the right subtree
                Right.Insert(value);
            }
        }
        // If the value is equal to the current node's value, do nothing.
        // This effectively ignores duplicate values, ensuring that each value in the tree is unique.
    }



    public bool Contains(int value) {
        // Check if the current node's value matches the search value
        if (value == Data) {
            // If the value matches, the value is found - return true
            return true;
        }
        else if (value < Data) {
            // If the search value is less than the current node's value,
            // the target must be in the left subtree (if it exists)
            if (Left != null) {
                // If the left child exists, recursively search the left subtree
                return Left.Contains(value);
            }
        }
        else {
            // If the search value is greater than the current node's value,
            // the target must be in the right subtree (if it exists)
            if (Right != null) {
                // If the right child exists, recursively search the right subtree
                return Right.Contains(value);
            }
        }

        // If we reach here, it means the value does not exist in the tree
        // (the search value is not equal to the current node's value,
        // and there are no more children in the direction we need to search)
        return false;
    }

    public int GetHeight() {
        // The height of a node is 1 plus the height of its tallest subtree.

        // First, calculate the height of the left subtree.
        // If there is no left child, Left.GetHeight() is not called since Left is null.
        // In this case, the height of the missing subtree as 0.
        int leftHeight = Left != null ? Left.GetHeight() : 0;

        // Similarly, calculate the height of the right subtree.
        int rightHeight = Right != null ? Right.GetHeight() : 0;

        // The height of the current node is one more than the height of its tallest subtree.
        // We add 1 to account for the current node itself.
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}