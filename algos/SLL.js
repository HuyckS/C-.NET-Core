/**
 * Singly-Linked List Node class
 * @param {any} val
 */

class SLLNode {
  constructor(val) {
    this.val = val;
    this.next = null;
  }
}
/**
 * Singly-Linked List class
 */

class SLL {
  constructor() {
    this.head = null; // the list is initially empty
  }

  /**
   * Determines if the list is empty.
   * 
   * @returns {boolean}
   */

  logTail() {
    if (this.head) {
      console.log(this.tail);
    }
  }

  isEmpty() {
    // your code here
    // return this.head;
    if (this.head === null) {
      return true;
    } else {
      return false;
    }

    // this works as well
    // return this.head === null;

    // console.log('5' == 5);
  }

  /**
   * Adds a node to the end of the list.
   * 
   * @param {any} val the value to add
   * @returns {SLL} the list
   */


  insertAtBack(val) {
    const node = new SLLNode(val);

    if (!this.head) {
      this.head = node;
    } else {
      let runner = this.head;

      while (runner.next) {
        runner = runner.next;
      }

      runner.next = node;
    }

    return this.tail;
  }

  /**
   * Adds all the array values to the list.
   * 
   * @param {any[]} arr an array of values
   * @returns {SLL} the list
   */

  seedFromArr(arr) {
    // your code here
    // optimize this!
    // how can we avoid traversing the entire list for each item?
    for (var i = 0; i < arr.length; i++) {
      this.insertAtBack(arr[i]);
    }

    return this;
  }

  /**
   * Prints a comma-separated list of the values.
   * 
   * @returns {void}
   */

  display() {
    // your code here
  }
}

const list = new SLL();
list.insertAtBack(1);

list.insertAtBack(1);
list.insertAtBack(2);
list.insertAtBack(3);
list.insertAtBack(4);

list.logTail();

