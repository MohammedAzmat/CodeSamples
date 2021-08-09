import MakeBTreeFromArray as MK
class BTreeFunctions:
    def FindTargetPath(self, root, target):
        if root is None:
            return
        paths = []
        self.GetPaths(root, target, paths, 0, [])
        return paths

    def popList(self, tempList):
        if len(tempList) > 0:
            tempList.pop()
    
    def GetPaths(self, root, target, paths, tempSum, tempPath):
        if root is None:
            return
        tempSum += root.val
        tempPath.append(root.val) 
        if tempSum == target:
            paths.append(tempPath.copy())
            return
        elif tempSum > target:
            return
        else:
            self.GetPaths(root.left, target, paths, tempSum, tempPath)
            self.popList(tempPath)
            self.GetPaths(root.right, target, paths, tempSum, tempPath)
            self.popList(tempPath)
            


        
        

        



A = MK.MakeTree()
tree = A.MakeBTree([1,2,3,None, 4,5,None])
tree = A.MakeBTree([5,4,8,11,None,13,4,7,2,None,None,5,1])
A.Inorder(tree) 
B = BTreeFunctions()
print(B.FindTargetPath(tree, 22))