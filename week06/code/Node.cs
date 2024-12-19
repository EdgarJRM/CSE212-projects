public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        // Check to avoid duplicates
        if (value == Data){
            // The value already exists, do nothing.
            return; 
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data){
            return true; // The value was found at this node.
        }

        if (value < Data){
            // Search in the left subtree.
            if (Left == null){
                return false; // There is no left subtree, so the value is not there.
            }else{
                return Left.Contains(value); // Recursive search.
            }
        }else{
            // Search in the right subtree.
            if (Right == null){
                return false; // There is no right subtree, so the value is not there.
            }else{
                return Right.Contains(value); // Recursive search.
            }
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        if (Left == null && Right == null){
            return 1; // It is an empty knot.
        }

        if (Left == null){
            return 1 + Right!.GetHeight(); // Only the right subtree exists.
        }

        if (Right == null){
            return 1 + Left.GetHeight(); // Only the left subtree exists.
        }

        return 1 + Math.Max(Left.GetHeight(), Right.GetHeight()); // Both subtrees exist.
    }
}