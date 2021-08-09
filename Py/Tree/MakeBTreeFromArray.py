class BTree:
    def __init__(self, val=None, left = None, right = None):
        self.val = val
        self.right = right
        self.left = left

class MakeTree:
    def MakeBTree(self, arr):
        if arr is None or len(arr) == 0:
            return None
        root = BTree(arr[0])
        self.MakeSubTree(root, arr, 0)
        return root
    
    def MakeSubTree(self, root, arr, i):
        if root is None or i > len(arr):
            return
        lc = 2*i + 1
        if lc < len(arr) and arr[lc] is not None:
            root.left = BTree(arr[lc])
            self.MakeSubTree(root.left,arr,lc)
        rc = lc + 1
        if rc < len(arr) and arr[rc] is not None:
            root.right = BTree(arr[rc]) 
            self.MakeSubTree(root.right,arr,rc)
    
    def Inorder(self, root):
        if root is None:
            return
        self.Inorder(root.left)
        print(root.val)
        self.Inorder(root.right)



        
    