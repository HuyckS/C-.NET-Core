class SLLNode {
    constructor(val) {
      this.val = val;
      this.next = null;
    }
  }
  
  class SLL {
    constructor() {
      this.head = null;
    }
  
    insertAtBack(val) {
      const newNode = new SLLNode(val);
  
      if(!this.head) {
        this.head = newNode;
        return this;
      }
  
      let current = this.head;
  
      while(current.next) {
        current = current.next;
      }
  
      current.next = newNode;
  
      return this;
    }
  
    /**
     * Reverses the list in place.
     * Don't create a new list.
     * 
     * @returns {SLL} the list
     */
  
    reverse() {
      // your code here
    }
  
    /**
     * Determines whether the list has a loop.
     * 
     * @returns {boolean}
     */
  
    hasLoop() {
      // your code here
    }
  
    /**
     * Removes all the nodes with negative values.
     * 
     * @returns {SLL} the list
     */
  
    removeNegatives() {
      // your code here
    }
  }
  
  const list = new SLL();
  
  list
    .insertAtBack(1)
    .insertAtBack(2)
    .insertAtBack(-2)
    .insertAtBack(3)
    .insertAtBack(-1);
  // 1 -> 2 -> -2 -> 3 -> -1
  
  list.reverse();
  // -1 -> 3 -> -2 -> 2 -> 1
  
  console.log(list.head.val); // should log -1
  
  list.removeNegatives();
  // 3 -> 2 -> 1
  
  console.log(list.head.next.val); // should log 2
  
  console.log(list.hasLoop()); // should log false
  
  list.head.next.next.next = list.head;
  // 3 -> 2 -> 1 -> 3 -> 2 -> 1 ...
  
  console.log(list.hasLoop()); // should log true
  