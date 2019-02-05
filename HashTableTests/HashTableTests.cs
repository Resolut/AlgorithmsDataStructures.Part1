﻿using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures.Tests
{
    [TestClass()]
    public class HashTableTests
    {
        [TestMethod()]
        public void HashFun_if_String_is_Empty()
        {
            HashTable hTable = new HashTable(19, 3);
            string emptyStr = "";

            Assert.IsTrue(hTable.HashFun(emptyStr) == 0);
        }

        [TestMethod()]
        public void HashFun_if_String_has_chars()
        {
            HashTable hTable = new HashTable(19, 3);
            string str = "A";
            string str2 = "Test";
            string str3 = "TEST";
            string str4 = "Test: 1";

            Assert.IsTrue(hTable.HashFun(str) == 8);
            Assert.IsTrue(hTable.HashFun(str2) == 17);
            Assert.IsTrue(hTable.HashFun(str3) == 16);
            Assert.IsTrue(hTable.HashFun(str4) == 4);
        }

        [TestMethod()]
        public void SeekSlot_if_hTable_is_Null()
        {
            HashTable hTable = new HashTable(19, 3);

            Assert.IsTrue(hTable.SeekSlot("TEST") == 16);
        }

        [TestMethod()]
        public void SeekSlot_if_Slot_Already_Has_Value()
        {
            HashTable hTable = new HashTable(19, 3);
            string value = "TEST";
            string value2 = "AA";

            int expectedStartSlot = 16;
            int startSlot = hTable.SeekSlot(value);
            hTable.Put(value);

            Assert.AreEqual(expectedStartSlot, startSlot);
            Assert.AreEqual(value, hTable.slots[16]);

            int expectedTargetSlot = 0;
            int targetSlot = hTable.SeekSlot(value2);

            Assert.AreEqual(expectedTargetSlot, targetSlot);
        }

        [TestMethod()]
        public void SeekSlot_if_HashTable_is_full()
        {
            HashTable hTable = new HashTable(5, 3);
            string value1 = "A";
            string value2 = "B";
            string value3 = "C";
            string value4 = "D";
            string value5 = "E";
            string target = "F";

            hTable.Put(value1);
            hTable.Put(value2);
            hTable.Put(value3);
            hTable.Put(value4);
            hTable.Put(value5);

            int expectedFailSlot = -1;
            int startSlot = hTable.SeekSlot(target);
            Assert.AreEqual(expectedFailSlot, startSlot);
            Assert.AreEqual(value1, hTable.slots[0]);
        }

        [TestMethod()]
        public void SeekSlot_if_HashTable_is_Partially_Full()
        {
            HashTable hTable = new HashTable(5, 3);
            string value1 = "A";
            string value2 = "B";

            string value3 = "D";
            string value4 = "E";

            string target = "H";

            hTable.Put(value1);
            hTable.Put(value2);
            hTable.Put(value3);
            hTable.Put(value4);

            int expectedSlot = 2;
            int startSlot = hTable.SeekSlot(target);

            Assert.AreEqual(expectedSlot, startSlot);

            hTable.Put(target);

            Assert.AreEqual(target, hTable.slots[2]);
        }

        [TestMethod()]
        public void SeekSlot_if_Two_Slots_Are_Busy()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[0] = "A";
            hTable.slots[3] = "F";
            hTable.slots[1] = "K";
            hTable.slots[4] = "P";
            string target = "U";
            int targetSlot = hTable.SeekSlot(target);

            System.Console.WriteLine("Log");

            int expectedSlot = -1;


            Assert.AreEqual(expectedSlot, targetSlot);

            hTable.Put(target);

            Assert.IsNull(hTable.slots[2]);
        }

        [TestMethod()]
        public void SeekSlot_if_Fisrt_Slot_Are_Busy()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[0] = "A";
            hTable.slots[2] = "F";
            hTable.slots[1] = "K";
            hTable.slots[4] = "P";

            string target = "U";

            int targetSlot = hTable.SeekSlot(target);
            int expectedSlot = 3;

            Assert.AreEqual(expectedSlot, targetSlot);
        }

        [TestMethod()]
        public void SeekSlot_if_2_Slots_Are_Busy_and_Iteration_Ends()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[0] = "A";
            hTable.slots[3] = "F";

            string target = "U";

            int targetSlot = hTable.SeekSlot(target);
            int expectedSlot = -1;

            Assert.AreEqual(expectedSlot, targetSlot);
        }

        [TestMethod()]
        public void SeekSlot_if_2_Slots_are_Busy()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[4] = "E";
            hTable.slots[2] = "J";

            string target = "O";

            int targetSlot = hTable.SeekSlot(target);
            int expectedSlot = 0;

            Assert.AreEqual(expectedSlot, targetSlot);
        }

        [TestMethod()]
        public void SeekSlot_if_Last_Slot_is_Busy_and_Iteration_Ends()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[4] = "E";
            hTable.slots[2] = "J";

            string target = "O";

            int targetSlot = hTable.SeekSlot(target);
            int expectedSlot = 0;

            Assert.AreEqual(expectedSlot, targetSlot);
        }

        [TestMethod()]
        public void SeekSlot_if_3_Slots_are_Busy()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[4] = "E";
            hTable.slots[2] = "J";
            hTable.slots[0] = "O";

            string target = "T";

            int targetSlot = hTable.SeekSlot(target);
            int expectedSlot = 3;

            Assert.AreEqual(expectedSlot, targetSlot);
        }

        [TestMethod()]
        public void SeekSlot_if_4_Slots_are_Busy()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[4] = "E";
            hTable.slots[2] = "J";
            hTable.slots[0] = "O";
            hTable.slots[3] = "T";

            string target = "Y";

            int targetSlot = hTable.SeekSlot(target);
            int expectedSlot = 1;

            Assert.AreEqual(expectedSlot, targetSlot);
        }

        [TestMethod()]
        public void SeekSlot_if_All_Slots_are_Busy_startSlot_4()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[4] = "E";
            hTable.slots[2] = "J";
            hTable.slots[0] = "O";
            hTable.slots[3] = "T";
            hTable.slots[1] = "Y";

            string target = "c";

            int targetSlot = hTable.SeekSlot(target);
            int expectedSlot = -1;

            Assert.AreEqual(expectedSlot, targetSlot);
        }

        [TestMethod()]
        public void SeekSlot_if_All_Slots_are_Busy_startSlot_0()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[4] = "U";
            hTable.slots[2] = "K";
            hTable.slots[0] = "A";
            hTable.slots[3] = "P";
            hTable.slots[1] = "F";

            string target = "Z";

            int targetSlot = hTable.SeekSlot(target);
            int expectedSlot = -1;

            Assert.AreEqual(expectedSlot, targetSlot);
        }

        [TestMethod()]
        public void SeekSlot_if_All_Slots_are_Busy_startSlot_2()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[2] = "C";
            hTable.slots[0] = "H";
            hTable.slots[3] = "M";
            hTable.slots[1] = "R";
            hTable.slots[4] = "W";

            string target = "a";

            int targetSlot = hTable.SeekSlot(target);
            int expectedSlot = -1;

            Assert.AreEqual(expectedSlot, targetSlot);
        }

        [TestMethod()]
        public void PutTest_if_hTable_is_empty()
        {
            HashTable hTable = new HashTable(19, 3);
            string value = "Test";

            int expectedSlot = 17;
            int actualSlot = hTable.Put(value);

            Assert.AreEqual(expectedSlot, actualSlot);
            Assert.AreEqual(value, hTable.slots[17]);
        }

        [TestMethod()]
        public void Put_if_hTable_Slot_is_already_Has_Value()
        {
            HashTable hTable = new HashTable(19, 3);
            string value = "TEST";
            string value2 = "AA";

            int expectedSlot = 16;
            int actualSlot = hTable.Put(value);

            Assert.AreEqual(expectedSlot, actualSlot);
            Assert.AreEqual(value, hTable.slots[16]);

            int failSlot = hTable.Put(value2);
            int expectedFail = -1;

            Assert.AreEqual(expectedFail, failSlot);
            Assert.AreEqual(value, hTable.slots[16]);
        }

        [TestMethod()]
        public void Find_If_value_Exists_in_HashTable()
        {
            HashTable hTable = new HashTable(19, 3);
            string value = "Test";

            hTable.Put(value);

            int expectedSlot = 17;
            int actualFoundSlot = hTable.Find(value);

            Assert.AreEqual(expectedSlot, actualFoundSlot);
            Assert.AreEqual(value, hTable.slots[17]);
        }

        [TestMethod()]
        public void Find_If_HashTable_Has_not_the_Value()
        {
            HashTable hTable = new HashTable(19, 3);
            string value = "AA";
            string target = "TEST";

            hTable.Put(value);

            int expectedFailSlot = -1;
            int actualFoundSlot = hTable.Find(target);

            Assert.AreEqual(expectedFailSlot, actualFoundSlot);
            Assert.AreEqual(value, hTable.slots[16]);
        }

        [TestMethod()]
        public void FindTest_if_Target_Has_Same_Hash_Is_Not_Found()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[2] = "C";
            hTable.slots[0] = "H";
            hTable.slots[3] = "M";
            hTable.slots[1] = "R";
            hTable.slots[4] = "W";

            int expected = -1;
            int actual = hTable.Find("a");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindTest_if_Found_in_LastSlot()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[2] = "C";
            hTable.slots[0] = "H";
            hTable.slots[3] = "M";
            hTable.slots[1] = "R";
            hTable.slots[4] = "W";

            int expected = 2;
            int actual = hTable.Find("C");

            int expected_1 = 0;
            int actual_1 = hTable.Find("H");

            int expected_2 = 3;
            int actual_2 = hTable.Find("M");

            int expected_3 = 1;
            int actual_3 = hTable.Find("R");

            int expected_4 = 4;
            int actual_4 = hTable.Find("W");
            
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected_1, actual_1);
            Assert.AreEqual(expected_2, actual_2);
            Assert.AreEqual(expected_3, actual_3);
            Assert.AreEqual(expected_4, actual_4);
        }

        [TestMethod()]
        public void FindTest_Found_in_Order()
        {
            HashTable hTable = new HashTable(5, 3);
            hTable.slots[0] = "A";
            hTable.slots[1] = "B";
            hTable.slots[2] = "J";
            hTable.slots[3] = "D";
            hTable.slots[4] = "E";

            int expected = 0;
            int actual = hTable.Find("A");

            int expected_1 = 1;
            int actual_1 = hTable.Find("B");

            int expected_2 = -1;
            int actual_2 = hTable.Find("C");

            int expected_3 = 3;
            int actual_3 = hTable.Find("D");

            int expected_4 = 2;
            int actual_4 = hTable.Find("J");

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected_1, actual_1);
            Assert.AreEqual(expected_2, actual_2);
            Assert.AreEqual(expected_3, actual_3);
            Assert.AreEqual(expected_4, actual_4);
        }
    }
}