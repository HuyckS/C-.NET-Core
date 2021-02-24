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
      if(!node) return;
  
      if(node.left) {
        this.print(node.left);
      }
  
      console.log(node.val);
  
      if(node.right) {
        this.print(node.right);
      }
    }
  
    /**
     * Determines if the value is in the tree.
     * Stretch for recursion if you can.
     * 
     * @returns {boolean}
     */
  
    contains(val) {
      // your code here
    }
  
    /**
     * Determines the difference between the max and the min values.
     * 
     * @returns {number|null} an integer or null if empty
     */
  
    range() {
      // your code here
    }
  }
  
  const bst = new BST();
  
  const root = bst.root = new BSTNode(20);
  
  root.left = new BSTNode(10);
  
  root.right = new BSTNode(30);
  
  root.left.left = new BSTNode(5);
  
  root.right.left = new BSTNode(25);
  root.right.right = new BSTNode(40);
  
  console.log(bst.contains(2)); // should log false
  console.log(bst.contains(25)); // should log true
  
  console.log(bst.range()); // should log 35 (40 - 5)
  
  //      20
  //     /  \
  //   10   30
  //  /    /  \
  // 5    25  40