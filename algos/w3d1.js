class BSTNode {
    constructor(val) {
        this.val = val;
        this.left = null;
        this.right = null;
    }
}

class BST {
    constructor() {
        this.root = null;
    }

    print(node = this.root) {
        if (!node) return;

        if (node.left) {
            this.print(node.left);
        }

        console.log(node.val);

        if (node.right) {
            this.print(node.right);
        }
    }

    /**
     * Determines if the BST is empty
     * 
     * @returns {boolean}
     */

    isEmpty() {
        // your code here
    }

    /**
     * Returns the minimum value in the BST: stretch for recursion
     * 
     * @param {BSTNode} node the starting node
     * @returns {number|null} the minimum value or null if empty
     */

    min(node = this.root) {
        if (node.val == null) {
            return null;
        }
        let i = 0;
        while (i != 1) {
            if (node.left == null) {
                return node.val;
                i++;
            }
            node = node.left;
        }
        return node.val;

    }

    //min(node = this.root) {
    // if(node.val == null){
    //     return null;
    //   }

    //   while(node.left!=null){
    //     node = node.left;
    //   }
    //   return node.val;

    // }
    /**
     * Returns the maximum value in the BST: stretch for recursion
     * 
     * @param {BSTNode} node the starting node
     * @returns {number|null} the maximum value or null if empty
     */

    max(node = this.root) {
        // your code here
    }
}

const bst = new BST();

const root = bst.root = new BSTNode(20);

console.log(bst.isEmpty()); // should log false

root.left = new BSTNode(10);

root.right = new BSTNode(30);

root.left.left = new BSTNode(5);

root.right.left = new BSTNode(25);
root.right.right = new BSTNode(40);

console.log(bst.min()); // should log 5

console.log(bst.max()); // should log 40

  //      20
  //     /  \
  //   10   30
  //  /    /  \
  // 5    25  40