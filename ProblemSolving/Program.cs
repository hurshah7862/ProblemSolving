// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Mail;
using System.Text;
using OpenPop.Mime;
using OpenPop.Pop3;

int[] arr = { 6, 1, 4, 5, 3, 9, 0, 1, 9, 5, 1, 8, 6, 7, 0, 5, 5, 4, 3 };
int[] inp = { -1, 0, 1, 2, -1, -4 };
int[] inputArr = { 1, 3, 1, -1, 3 };
int[] nums1 = { 4, 5, 6, 0, 0, 0 }; int m = 3; int[] nums2 = { 1, 2, 3 }; int n = 3;
int num = 123454321;
int input = 1534236469;
string s = "egg", t = "add";
string x = "au";
int[] head = { 0, 1, 2 };
//int m = 1;
//int n = 4;
//Console.WriteLine(Convert.ToString(RemoveDuplicates(arr)));
//Console.WriteLine(Convert.ToString(IsPalindrome(num)));
//Console.WriteLine(Convert.ToString(ContainsDuplicate(arr)));
//Console.WriteLine(Convert.ToString(MaxArea(arr)));
//Console.WriteLine(Convert.ToString(PlusOne(arr)));
//Console.WriteLine(Convert.ToString(IsIsomorphic(s, t)));
//Console.WriteLine(Convert.ToInt32(Reverse(input)));
//Console.WriteLine(Convert.ToInt32(LengthOfLongestSubstring(x)));
//AddTwoNumbers(ListToLinkList(new List<int>() { 9, 9, 9, 9, 9, 9, 9 }), ListToLinkList(new List<int>() { 9, 9, 9, 9 }));
//MergeTwoLists(ListToLinkList(new List<int>() { 1, 2, 4 }), ListToLinkList(new List<int>() { 1, 3, 4 }));
//SpiralMatrix(m, n, ListToLinkList(head.ToList()));
//Console.WriteLine(Convert.ToString(TitleToNumber("A")));
//DictionaryTest();
//MergeTwoLists2(ListToLinkList(new List<int>() { 1, 2, 4 }), ListToLinkList(new List<int>() { 1, 3, 4 }));
//ReadEmails();
Merge(nums1, m, nums2, n);
//Console.WriteLine(Convert.ToString(ThirdMax(inp)));
//OrderdMap();

#region Problems


//List<List<int>> NumberOfMaxPairs(List<int> input)
//{
//    if(input.Count()== 1)
//    {
//        return new List<List<int>> { input };
//    }
//    int current = input[0];
//    input.RemoveAt(0);
//    List<List<int>> response = NumberOfMaxPairs(input);
//    int inp= input.Count();
//    for(int i = 0;i < inp;i++)
//    {
//        var itemToAdd = response[inp - i - 1];
//        itemToAdd.Insert(0, current);
//        response.Add(itemToAdd);
//    }
//}


void DictionaryTest()
{
    int i = (int)(5 / 2);
    var test = new OrderedDictionary();
    test.Add(3, "three");
    test.Add(2, "two");
    test.Add(1, "one");
    test.Add(0, "zero");
    test.Remove(2);
    test.Add(5, "five");
    test.RemoveAt(0);
    Console.WriteLine(test[(object)10]);
    foreach (var item in test.Keys)
    {
        Console.WriteLine(item);
    }
    foreach (DictionaryEntry de in test)
    {
        System.Console.WriteLine(de.Key + ", " + de.Value);
    }
}

void Merge(int[] nums1, int m, int[] nums2, int n)
{
    if (n != 0)
    {
        int i = m - 1;
        int j = n - 1;
        for (int k = nums1.Length - 1; k >= 0; k--)
        {
            if (nums1[i] <= nums2[j])
            {
                nums1[k] = nums2[j];
                j--;
            }
            else
            {
                nums1[k] = nums1[i];
                nums1[i] = nums2[j];
                i++;
            }
            i--;
        }
    }
}

bool HasCycle(ListNode head)
{
    ListNode fast = head;
    ListNode slow = head;
    while (fast != null && fast.next != null)
    {
        fast = fast.next.next;
        slow = slow.next;
        if (fast == slow)
            return true;
    }
    return false;

}
bool IsValid(string s)
{
    Stack stack = new Stack();
    Dictionary<char, char> dic = new Dictionary<char, char>();
    dic.Add(')', '(');
    dic.Add('}', '{');
    dic.Add(']', '[');
    char check;
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == '(' || s[i] == '{' || s[i] == '[')
            stack.Push(s[i]);
        else
        {
            if (stack.Count > 0)
            {
                char val = (char)stack.Pop();

                if (val != dic[s[i]])
                    return false;
            }
            else return false;

        }
    }
    if (stack.Count == 0)
        return true;
    else
        return false;
}
int TrailingZeroes(int n)
{
    int result = 0;
    if (n == 0)
        return result;
    long factorial = 1;
    for (int i = n; i > 1; i--)
    {
        factorial = factorial * i;
    }
    while (factorial % 10 == 0)
    {
        factorial = factorial / 10;
        result++;
    }
    return result;
}
int RemoveDuplicates2(int[] nums)
{

    if (nums.Length == 1)
        return 1;

    int start = 1;
    int end = 1;
    while (end < nums.Length)
    {
        if (nums[end] != nums[start - 1])
        {
            if (nums[start - 1] >= nums[start])
                nums[start] = nums[end];
            start++;
        }
        end++;

    }
    return start;
    // HashSet<int> hash = new HashSet<int>();
    // int check;
    // int total = 0;
    // for(int i = 0; i < nums.Length; i++)
    // {
    //     if(!hash.TryGetValue(nums[i], out check))
    //     {
    //         hash.Add(nums[i]);
    //         total++;
    //     }
    // }
    // return total;
}
string CountAndSay(int n)
{
    if (n == 1)
    {
        return "1";
    }
    string str = CountAndSay(n - 1);
    string result = "";
    char current = '\0';
    int count = 0;
    for (int i = 0; i < str.Length; i++)
    {
        if (current == str[i])
            count++;
        else if (current != '\0')
        {
            result = result + count.ToString() + current.ToString();
            current = str[i];
            count = 1;
        }
        else
        {
            current = str[i];
            count = 1;
        }
    }
    if (current != '\0')
    {
        result = result + count.ToString() + current.ToString();
    }
    return result;
}
int[] PlusOne2(int[] digits)
{
    Stack stack = new Stack();
    int reminder = 1;
    for (int i = digits.Length - 1; i >= 0; i--)
    {
        if (digits[i] + reminder > 9)
        {
            stack.Push((digits[i] + reminder) % 10);
            reminder = 1;
        }
        else
        {
            stack.Push(digits[i] + reminder);
            reminder = 0;
        }
    }
    if (reminder > 0)
        stack.Push(reminder);
    int[] result = new int[stack.Count];
    for (int i = 0; i < result.Length; i++)
    {
        result[i] = (int)stack.Pop();
    }
    return result;

}
int HammingWeight(uint n)
{
    string inp = Convert.ToString(n, 2);
    inp = inp.Replace("0", "");
    return inp.Length;
}
bool IsPowerOfThree(int n)
{
    if (n == 3 || n == 1)
        return true;
    if (n % 3 != 0 || n < 1)
        return false;
    else
        return IsPowerOfThree(n / 3);
}
int MaxSubArray(int[] nums)
{
    int maxSum = nums[0];
    int current = nums[0];
    for (int i = 1; i < nums.Length; i++)
    {
        current = Math.Max(nums[i], nums[i] + current);
        maxSum = Math.Max(maxSum, current);
    }
    return maxSum;
}
bool IsSymmetric(TreeNode root)
{
    return IsSymmetricOverride(root.left, root.right);
}
bool IsSymmetricOverride(TreeNode left, TreeNode right)
{
    if (left == null && right == null)
        return true;
    else if (left == null || right == null)
        return false;
    return left.val == right.val && IsSymmetricOverride(left.right, right.left) && IsSymmetricOverride(left.left, right.right);

}
IList<IList<int>> Generate(int numRows)
{
    IList<IList<int>> result = new List<IList<int>>();
    List<int> current = new List<int>();
    if (numRows == 1)
    {
        current = new List<int>();
        current.Add(1);
        result.Add(current);
        current = new List<int>();
        return result;
    }
    result = Generate(numRows - 1);
    current.Add(1);
    for (int i = 0; i < numRows - 2; i++)
    {
        current.Add(result[result.Count() - 1][i] + result[result.Count() - 1][i + 1]);
    }
    current.Add(1);
    result.Add(current);
    current = new List<int>();
    return result;
}
bool IsHappy(int n)
{
    int check;
    HashSet<int> hash = new HashSet<int>();
    while (n != 1 && !hash.TryGetValue(n, out check))
    {
        hash.Add(n);
        n = Square(n);
    }

    return n == 1 ? true : false;
}
int Square(int num)
{
    int square = 0;
    while (num > 0)
    {
        int reminder = num % 10;
        square += reminder * reminder;
        num /= 10;
    }
    return square;
}

ListNode MergeTwoLists3(ListNode list1, ListNode list2)
{

    if (list1 == null && list2 == null)
        return list1;
    if (list1 == null)
    {
        return list2;
    }
    if (list2 == null)
    {
        return list1;
    }
    if (list1.val > list2.val)
    {

        list2.next = MergeTwoLists(list1, list2.next);
        return list2;
    }
    else
    {
        list1.next = MergeTwoLists(list1.next, list2);
        return list1;
    }
}
ListNode MergeTwoLists2(ListNode list1, ListNode list2)
{

    return MergeTwoListsOverload(list1, list2, null);
}
ListNode MergeTwoListsOverload(ListNode list1, ListNode list2, ListNode list1Parent)
{
    if (list1 == null && list2 == null)
        return list1;
    if (list1 == null)
    {
        return list2;
    }
    if (list2 == null)
    {
        return list1;
    }
    if (list1.val > list2.val)
    {
        if (list1Parent != null)
        {
            list1Parent.next = list2;
            list2 = list1;
            list1 = list1Parent;
            list1 = MergeTwoListsOverload(list1.next, list2, list1);
        }
        else
        {
            list1Parent = list2;
            list2 = list1;
            list1 = list1Parent;
            list1 = MergeTwoListsOverload(list1, list2, null);
        }
    }
    else
    {
        list1.next = MergeTwoListsOverload(list1.next, list2, list1);
    }

    return list1;
}
int MaxProfitUsingOneArray(int[] prices)
{
    int buy = 0;
    int sell = 0;
    int max = 0;
    for (int i = 0; i < prices.Length; i++)
    {
        if ((prices[sell] - prices[buy] > max) && sell > buy)
            max = prices[sell] - prices[buy];
        if (prices[i] > prices[sell])
            sell = i;
        if (prices[i] < prices[buy])
        {
            buy = i;
            sell = i;
        }
    }
    if ((prices[sell] - prices[buy] > max) && sell > buy)
        max = prices[sell] - prices[buy];
    return max;
}
int[] Intersect(int[] nums1, int[] nums2)
{
    int check;
    List<int> result = new List<int>();
    Dictionary<int, int> nums1Dic = new Dictionary<int, int>();
    for (int i = 0; i < nums1.Length; i++)
    {
        if (nums1Dic.TryGetValue(nums1[i], out check))
            nums1Dic[nums1[i]] += 1;
        else
            nums1Dic.Add(nums1[i], 1);
    }
    for (int i = 0; i < nums2.Length; i++)
    {
        if (nums1Dic.TryGetValue(nums2[i], out check))
        {
            nums1Dic[nums2[i]] -= 1;
            if (nums1Dic[nums2[i]] == 0)
                nums1Dic.Remove(nums2[i]);
            result.Add(nums2[i]);
        }
    }
    return result.ToArray();

}
int MissingNumberUsingXOR(int[] nums)
{
    int result = 0;
    for (int i = 1; i <= nums.Length; i++)
    {
        result ^= i;
        result ^= nums[i - 1];
    }
    return result;

}
int MissingNumber(int[] nums)
{
    int check;
    HashSet<int> hash = new HashSet<int>();
    for (int i = 0; i < nums.Length; i++)
    {
        hash.Add(nums[i]);
    }
    for (int i = 0; i <= nums.Length; i++)
    {
        if (!hash.TryGetValue(i, out check))
            return i;
    }
    return 0;

}
TreeNode SortedArrayToBST(int[] nums)
{
    return SortedArrayToBSTHelper(nums, 0, nums.Length - 1);
}
TreeNode SortedArrayToBSTHelper(int[] nums, int start, int end)
{
    TreeNode response = new TreeNode();
    if (start == end)
    {
        response.val = nums[start];
    }
    else if (start == end - 1)
    {
        response.val = nums[start];
        response.right = new TreeNode(nums[end]);
    }
    else if (end - start == 2)
    {
        response.val = nums[start + 1];
        response.right = new TreeNode(nums[end]);
        response.left = new TreeNode(nums[start]);
    }
    else
    {
        int mid = ((end + 1 - start) / 2) + start;
        response.val = nums[mid];
        response.right = SortedArrayToBSTHelper(nums, mid + 1, end);
        response.left = SortedArrayToBSTHelper(nums, start, mid - 1);
    }
    return response;
}
int FirstUniqChar(string s)
{
    int check;
    Dictionary<char, int> sDic = new Dictionary<char, int>();
    for (int i = 0; i < s.Length; i++)
    {
        if (sDic.TryGetValue(s[i], out check))
            sDic[s[i]] += 1;
        else
            sDic.Add(s[i], 1);
    }
    for (int i = 0; i < s.Length; i++)
    {
        if (sDic[s[i]] == 1)
            return i;
    }
    return -1;
}
bool ContainsDuplicateUsingHash(int[] nums)
{
    HashSet<int> temp = new HashSet<int>();
    int check;
    for (int i = 0; i < nums.Length; i++)
    {
        if (temp.TryGetValue(nums[i], out check))
            return true;
        else
            temp.Add(nums[i]);
    }
    return false;
}
bool IsAnagram(string s, string t)
{
    if (s.Length != t.Length)
        return false;
    Dictionary<char, int> sDic = new Dictionary<char, int>();
    Dictionary<char, int> tDic = new Dictionary<char, int>();
    int exists;
    for (int i = 0; i < s.Length; i++)
    {
        if (sDic.TryGetValue(s[i], out exists))
            sDic[s[i]] += 1;
        else
            sDic.Add(s[i], 1);
    }
    for (int i = 0; i < t.Length; i++)
    {
        if (tDic.TryGetValue(t[i], out exists))
            tDic[t[i]] += 1;
        else
            tDic.Add(t[i], 1);
    }
    foreach (var item in sDic)
    {
        if (tDic.TryGetValue(item.Key, out exists))
        {
            if (item.Value != tDic[item.Key])
                return false;
        }
        else
        {
            return false;
        }
    }
    return true;
}
int MaxProfit2(int[] prices)
{
    int buyIndex = 0;
    int sellIndex = 0;
    int totalSum = 0;
    for (int i = 0; i < prices.Length; i++)
    {
        if (prices[i] > prices[sellIndex])
            sellIndex = i;
        if (prices[i] < prices[sellIndex])
        {
            totalSum += prices[sellIndex] - prices[buyIndex];
            buyIndex = i;
            sellIndex = i;
        }
    }
    if (buyIndex < sellIndex)
        totalSum += prices[sellIndex] - prices[buyIndex];
    return totalSum;
}
int TitleToNumber(string columnTitle)
{
    int response = 0;
    Dictionary<string, int> mapping = new Dictionary<string, int>();
    mapping.Add("A", 1);
    mapping.Add("B", 2); mapping.Add("C", 3); mapping.Add("D", 4); mapping.Add("E", 5); mapping.Add("F", 6);
    mapping.Add("G", 7); mapping.Add("H", 8); mapping.Add("I", 9); mapping.Add("J", 10); mapping.Add("K", 11);
    mapping.Add("L", 12); mapping.Add("M", 13); mapping.Add("N", 14); mapping.Add("O", 15); mapping.Add("P", 16);
    mapping.Add("Q", 17); mapping.Add("R", 18); mapping.Add("S", 19); mapping.Add("T", 20); mapping.Add("U", 21);
    mapping.Add("V", 22); mapping.Add("W", 23); mapping.Add("X", 24); mapping.Add("Y", 25); mapping.Add("Z", 26);
    double iteration = 0;
    while (columnTitle.Length > 0)
    {
        string temp = columnTitle.Substring(columnTitle.Length - 1, 1);
        columnTitle = columnTitle.Substring(0, columnTitle.Length - 1);
        response += mapping[temp] * (int)Math.Pow(26, iteration);
        iteration++;
    }
    return response;
}
ListNode ReverseList2(ListNode head)
{
    if (head == null)
        return null;
    ListNode result = new ListNode();
    while (head != null)
    {
        result.val = head.val;
        if (head.next != null)
        {
            ListNode temp = new ListNode();
            temp.next = result;
            result = temp;
        }
        head = head.next;
    }
    return result;

}
int GetSum(int a, int b)
{
    while (b != 0)
    {
        var carry = a & b;
        a = a ^ b;
        b = carry << 1;
    }
    return a;
}
void MoveZeroes(int[] nums)
{
    int nonzero = 0;
    int zero = 0;
    while (nonzero < nums.Length && zero < nums.Length)
    {
        if (nums[nonzero] == 0)
        {
            nonzero++;
            continue;
        }
        if (nums[zero] != 0)
        {
            zero++;
            continue;
        }
        if (nums[nonzero] != 0 && nums[zero] == 0 && zero < nonzero)
        {
            int temp = nums[nonzero];
            nums[nonzero] = nums[zero];
            nums[zero] = temp;
            nonzero++;
            zero++;
        }
        else
            nonzero++;
    }
}



int max = 0;
int MaxDepth(TreeNode root)
{
    if (root == null)
        return 0;
    TraverseTree(root, 1);
    return max;
}
void TraverseTree(TreeNode root, int depth)
{
    if (depth > max)
        max = depth;
    if (root.left != null)
        TraverseTree(root.left, depth + 1);
    if (root.right != null)
        TraverseTree(root.right, depth + 1);
}
int SingleNumber2(int[] nums)
{
    int ans = 0;
    int n = nums.Length;

    for (int i = 0; i < n; i++)
    {
        ans = ans ^ nums[i];
    }

    return ans;
}
int SingleNumber(int[] nums)
{
    string str = "";
    for (int i = 0; i < nums.Length; i++)
    {
        if (str.Contains("," + nums[i].ToString() + ","))
            str = str.Replace("," + nums[i].ToString() + ",", "");
        else
            str += "," + nums[i].ToString() + ",";
    }
    for (int i = 0; i < nums.Length; i++)
    {
        if (str.Contains(nums[i].ToString()))
            return nums[i];
    }
    return 0;
}
void ReverseString(char[] s)
{
    char temp;
    int max = (int)((s.Length - 1) / 2);
    for (int i = 0; i <= max; i++)
    {
        temp = s[i];
        s[i] = s[s.Length - 1 - i];
        s[s.Length - 1 - i] = temp;
    }
}

Dictionary<int, int> memo = new Dictionary<int, int>();
int ClimbStairs(int n)
{
    int exists;
    if (memo.TryGetValue(n, out exists))
        return memo[n];
    if (n == 1)
        return 1;
    if (n == 2)
        return 2;
    memo.Add(n, ClimbStairs(n - 1) + ClimbStairs(n - 2));
    return memo[n];
}

int MaxProfit(int[] prices)
{
    int[] pricesMax = new int[prices.Length];
    pricesMax[pricesMax.Length - 1] = prices[prices.Length - 1];
    for (int i = prices.Length - 2; i >= 0; i--)
    {
        pricesMax[i] = prices[i] > pricesMax[i + 1] ? prices[i] : pricesMax[i + 1];
    }
    int max = 0;
    for (int i = 0; i < prices.Length - 1; i++)
    {
        if (pricesMax[i] - prices[i] > max)
            max = pricesMax[i] - prices[i];
    }
    return max;
}

int Rob(int[] nums)
{
    if (nums.Length < 2)
        return nums[0];
    else if (nums.Length == 2)
        return nums[0] > nums[1] ? nums[0] : nums[1];
    else if (nums.Length == 3)
    {
        int max = nums[0] > nums[1] ? nums[0] : nums[1];
        return max > nums[2] ? max : nums[2];
    }
    int[] numsStart = new int[nums.Length - 1];
    int[] numsEnd = new int[nums.Length - 1];
    for (int i = 0; i < nums.Length - 1; i++)
    {
        numsStart[i] = nums[i];
        numsEnd[i] = nums[i + 1];
    }
    int first = HouseRobber(numsStart);
    int last = HouseRobber(numsEnd);
    return first > last ? first : last;

}
int HouseRobber(int[] input)
{
    input[1] = input[0] > input[1] ? input[0] : input[1];
    for (int i = 2; i < input.Length; i++)
    {
        input[i] = input[i] + input[i - 2] > input[i - 1] ? input[i] + input[i - 2] : input[i - 1];
    }
    return input[input.Length - 1];
}
int[] InsertionSort(int[] input)
{
    for (int i = 1; i < input.Length; i++)
    {
        if (input[0] > input[i])
        {
            input = ReplaceItem(input, 0, i);
            continue;
        }
        else if (input[i] > input[i - 1])
        {
            continue;
        }
        int dec = i;
        while (dec > 0)
        {
            dec--;
            if (input[dec] < input[i])
            {
                input = ReplaceItem(input, dec + 1, i);
                break;
            }
        }
    }
    return input;
}
int[] ReplaceItem(int[] input, int leftIndex, int rightIndex)
{
    int rightItem = input[rightIndex];
    for (int i = rightIndex; i > leftIndex; i--)
    {
        input[i] = input[i - 1];
        if (i == leftIndex + 1)
        {
            input[i - 1] = rightItem;
        }
    }
    return input;
}

int[] SelectionSort(int[] input)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < input.Length; i++)
    {
        int smallestIndex = i;
        for (int j = i + 1; j < input.Length; j++)
        {
            if (input[j] < input[smallestIndex])
                smallestIndex = j;
        }
        int temp = input[smallestIndex];
        input[smallestIndex] = input[i];
        input[i] = temp;
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.Elapsed.ToString());
    return input;
}
int[] BubbleSort2(int[] input)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < input.Length - 1 - i; j++)
        {
            if (input[j] > input[j + 1])
            {
                int temp = input[j];
                input[j] = input[j + 1];
                input[j + 1] = temp;
            }
        }
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.Elapsed.ToString());
    return input;
}
int[] BubbleSort(int[] input)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    int sorted = 0;
    while (input.Length - sorted > 1)
    {
        sorted++;
        for (int j = 0; j < input.Length - 1; j++)
        {
            if (input[j] > input[j + 1])
            {
                int temp = input[j];
                input[j] = input[j + 1];
                input[j + 1] = temp;
            }
        }
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.Elapsed.ToString());
    return input;
}
string ReversingString(string str)
{
    if (str.Length == 1)
        return str;
    return ReversingString(str.Substring(1, str.Length - 1)) + str.Substring(0, 1);
}
int Fibonacci(int index)    //this implementation takes O(n^2) so loop should be used
{
    if (index < 5)
    {
        if (index < 2)
            return index;
        else
            return index - 1;
    }
    return Fibonacci(index - 1) + Fibonacci(index - 2);

}
int Factorial(int input)
{
    if (input == 1)
        return input;
    input--;
    return Factorial(input) * (input + 1);
}

IList<IList<int>> ThreeSum(int[] nums)
{
    nums = nums.OrderBy(x => x).ToArray();
    IList<IList<int>> result = new List<IList<int>>();
    var hash = new HashSet<string>();
    int target = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        int pointer1 = i + 1;
        int pointer2 = nums.Length - 1;
        while (pointer1 < pointer2)
        {
            if ((nums[i] + nums[pointer1] + nums[pointer2]) == target)
            {
                List<int> temp = new List<int>();
                temp.Add(nums[i]);
                temp.Add(nums[pointer1]);
                temp.Add(nums[pointer2]);
                temp = temp.OrderBy(x => x).ToList();
                string check;
                if (!hash.TryGetValue(String.Join(",", temp), out check))
                {
                    hash.Add(String.Join(",", temp));
                    result.Add(temp);
                }
            }

            if ((nums[i] + nums[pointer1] + nums[pointer2]) >= target)
            {
                pointer2--;
            }
            else
            {
                pointer1++;
            }
        }

    }
    return result;
}
int[] TwoSum(int[] nums, int target)
{
    Dictionary<int, int> dic = new Dictionary<int, int>();
    int[] result = new int[2];
    for (int i = 0; i < nums.Count(); i++)
    {
        int ou;
        if (dic.TryGetValue(nums[i], out ou))
        {
            result[0] = dic[nums[i]];
            result[1] = i;
            return result;
        }
        else if (!dic.TryGetValue(target - nums[i], out ou))
        {
            dic.Add(target - nums[i], i);
        }
    }
    return result;
}
int ThirdMax(int[] nums)
{
    SortedSet<int> sortedSet = new SortedSet<int>();
    for (int i = 0; i < nums.Length; i++)
    {
        sortedSet.Add(nums[i]);
    }
    var rev = sortedSet.Reverse();
    var enu = rev.GetEnumerator();
    enu.MoveNext();
    if (sortedSet.Count < 3)
        return enu.Current;
    else
    {
        enu.MoveNext();
        enu.MoveNext();
        return enu.Current;
    }
}
List<dynamic> ReadEmails()
{
    Pop3Client pop3Client = new Pop3Client();
    pop3Client.Connect("pop.gmail.com", 995, true); //SSL is true or false 
    pop3Client.Authenticate("hurshah7862", "vagu ixnb rfdi kefg");
    int count = pop3Client.GetMessageCount(); //total count of email in MessageBox  
    var Emails = new List<dynamic>();

    for (int i = count; i >= 1; i--)
    {
        Message message = pop3Client.GetMessage(i);

        OpenPop.Mime.MessagePart body = message.FindFirstHtmlVersion();

        List<OpenPop.Mime.MessagePart> attachments = message.FindAllAttachments();

        foreach (OpenPop.Mime.MessagePart attachment in attachments)
        {
            string ext = System.IO.Path.GetExtension(attachment.FileName);

        }


    }
    pop3Client.Disconnect();
    return Emails;
}
//int ThirdMax(int[] nums)
//{
//    int? first = null, second = null, third = null;
//    for (int i = 0; i < nums.Length; i++)
//    {
//        if (first == null || nums[i] > first)
//        {
//            third = second;
//            second = first;
//            first = nums[i];
//        }
//        else if (nums[i] < first && (second == null || nums[i] > second))
//        {
//            third = second;
//            second = nums[i];

//        }
//        else if (nums[i] < second && (third == null || nums[i] > third))
//        {
//            third = nums[i];
//        }
//    }
//    return Convert.ToInt32(third != null ? third : first);
//}
string IntToRoman(int num)
{
    int reminder = num;
    string response = "";
    while (reminder != 0)
    {
        num = reminder;
        switch (reminder)
        {
            case var expression when (reminder >= 1000):
                response = NumberToSymbol(1000, num, "M", out reminder, response);
                break;
            case var expression when (reminder >= 900 && reminder < 1000):
                response = NumberToSymbol(900, num, "CM", out reminder, response);
                break;
            case var expression when (reminder >= 500 && reminder < 900):
                response = NumberToSymbol(500, num, "D", out reminder, response);
                break;
            case var expression when (reminder >= 400 && reminder < 500):
                response = NumberToSymbol(400, num, "CD", out reminder, response);
                break;
            case var expression when (reminder >= 100 && reminder < 400):
                response = NumberToSymbol(100, num, "C", out reminder, response);
                break;
            case var expression when (reminder >= 90 && reminder < 100):
                response = NumberToSymbol(90, num, "XC", out reminder, response);
                break;
            case var expression when (reminder >= 50 && reminder < 90):
                response = NumberToSymbol(50, num, "L", out reminder, response);
                break;
            case var expression when (reminder >= 40 && reminder < 50):
                response = NumberToSymbol(40, num, "XL", out reminder, response);
                break;
            case var expression when (reminder >= 10 && reminder < 40):
                response = NumberToSymbol(10, num, "X", out reminder, response);
                break;
            case var expression when (reminder >= 9 && reminder < 10):
                response = NumberToSymbol(9, num, "IX", out reminder, response);
                break;
            case var expression when (reminder >= 5 && reminder < 9):
                response = NumberToSymbol(5, num, "V", out reminder, response);
                break;
            case var expression when (reminder >= 4 && reminder < 5):
                response = NumberToSymbol(4, num, "IV", out reminder, response);
                break;
            default:
                response = NumberToSymbol(1, num, "I", out reminder, response);
                break;
        }
    }
    return response;
}
int[,] SpiralMatrix(int m, int n, ListNode head)
{
    int[,] response = new int[m, n];
    int corner1 = 0, corner2 = 1, corner3 = n - 2, corner4 = m - 2, total = m * n, count = 0;
    while (count < total)
    {
        for (int i = corner1; i <= corner3 + 1; i++)
        {
            if (head != null)
            {
                response[corner2 - 1, i] = head.val;
                head = head.next;
            }
            else if (count < total)
                response[corner2 - 1, i] = -1;
            count++;
        }
        for (int i = corner2; i <= corner4 + 1; i++)
        {

            if (head != null)
            {
                response[i, corner3 + 1] = head.val;
                head = head.next;
            }
            else if (count < total)
                response[i, corner3 + 1] = -1;
            count++;
        }
        for (int i = corner3; i >= corner1; i--)
        {

            if (head != null)
            {
                response[corner4 + 1, i] = head.val;
                head = head.next;
            }
            else if (count < total)
                response[corner4 + 1, i] = -1;
            count++;
        }
        for (int i = corner4; i >= corner2; i--)
        {

            if (head != null)
            {
                response[i, corner1] = head.val;
                head = head.next;
            }
            else if (count < total)
                response[i, corner1] = -1;
            count++;
        }
        corner1++;
        corner2++;
        corner3--;
        corner4--;
    }
    return response;
}
ListNode MiddleNode(ListNode head)
{
    ListNode reference = head;
    ListNode response = null;
    int count = -1;
    while (reference != null)
    {
        count++;
        reference = reference.next;
    }
    response = head;
    count = (count + 1) / 2;
    while (count > 0)
    {
        count--;
        response = response.next; ;
    }
    return response;
}
string LongestPalindrome(string s)
{
    if (s.Length < 2)
        return s;
    var splitted = SplitString(s);
    if (splitted.Count() == 2 && splitted[0] == splitted[1])
    {
        return s;
    }
    string maxPalindrome = "";
    for (int i = 0; i < splitted.Count() - 1; i++)
    {
        string currentPalindrome = splitted[i];
        int j = i - 1;
        int k = i + 1;

        bool frontSame = true;
        bool backSame = true;
        while (j >= 0 || k <= splitted.Count() - 1)
        {
            string jVal = "";
            string kVal = "";
            if (j >= 0)
                jVal = splitted[j];
            if (k <= splitted.Count() - 1)
                kVal = splitted[k];
            if (kVal == jVal)
            {
                if (kVal != splitted[i])
                {
                    backSame = false;
                    frontSame = false;
                }
                currentPalindrome = jVal + currentPalindrome + kVal;
                j--;
                k++;
            }
            else if (splitted[i] == jVal && backSame)
            {
                currentPalindrome = jVal + currentPalindrome;
                j--;
            }
            else if (splitted[i] == kVal && frontSame)
            {
                currentPalindrome = currentPalindrome + kVal;
                k++;
            }
            else
            {
                break;
            }
        }
        if (currentPalindrome.Length > maxPalindrome.Length)
            maxPalindrome = currentPalindrome;
    }
    return maxPalindrome;
}
ListNode ReverseList(ListNode head)
{
    ListNode response = null;
    while (head != null)
    {
        if (response == null)
        {
            response = new ListNode();
            response.val = head.val;
            head = head.next;
        }
        else
        {
            ListNode node = new ListNode();
            node.val = head.val;
            node.next = response;
            response = node;
            head = head.next;
        }
    }
    return response;
}
ListNode MergeTwoLists(ListNode list1, ListNode list2)
{

    List<int> temp = new List<int>();
    while (list1 != null || list2 != null)
    {
        if (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                temp.Add(list1.val);
                list1 = list1.next;
            }
            else
            {
                temp.Add(list2.val);
                list2 = list2.next;
            }
        }
        else if (list1 == null)
        {
            temp.Add(list2.val);
            list2 = list2.next;
        }
        else if (list2 == null)
        {
            temp.Add(list1.val);
            list1 = list1.next;
        }
    }
    ListNode response = null;
    for (int i = temp.Count() - 1; i >= 0; i--)
    {
        if (response == null)
        {
            response = new ListNode();
            response.val = temp[i];
        }
        else
        {
            ListNode node = new ListNode();
            node.val = temp[i];
            node.next = response;
            response = node;
        }

    }
    return response;

}
ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    List<int> temp = new List<int>();
    ListNode result = null;
    int reminder = 0;
    int sum = l1.val + l2.val;
    if (sum > 9)
    {
        temp.Add(sum - 10);
        reminder = 1;
    }
    else
    {
        temp.Add(sum);
    }
    l1 = l1.next;
    l2 = l2.next;
    while (l1 != null || l2 != null)
    {
        sum = 0;
        if (l1 != null)
        {
            sum = sum + l1.val;
            l1 = l1.next;
        }
        if (l2 != null)
        {
            sum = sum + l2.val;
            l2 = l2.next;
        }
        sum = sum + reminder;
        reminder = 0;
        if (sum > 9)
        {
            temp.Add(sum - 10);
            reminder = 1;
        }
        else
        {
            temp.Add(sum);
        }
    }
    if (reminder > 0)
    {
        temp.Add(reminder);
        reminder = 0;
    }
    result = ListToLinkList(temp);
    return result;
}
int LengthOfLongestSubstring(string s)
{
    if (s.Length < 2)
        return s.Length;
    string resstr = "";
    int i = 0;
    int maxLength = 0;
    while (s.Length > 0)
    {
        string current = s.Substring(0, 1);
        s = s.Substring(1, s.Length - 1);
        if (resstr.Contains(current))
        {
            if (resstr.Length > maxLength)
                maxLength = resstr.Length;

            resstr = resstr.IndexOf(current) == resstr.Length - 1 ? "" : resstr.Substring(resstr.IndexOf(current) + 1, resstr.Length - resstr.IndexOf(current) - 1);
            resstr = resstr + current;
        }
        else
        {
            resstr = resstr + current;
            if (resstr.Length > maxLength)
                maxLength = resstr.Length;
        }
        i++;
    }
    return maxLength;
}
void OrderdMap()
{
    var orderdDictionary = new OrderedDictionary();
    orderdDictionary.Add("5", 1);
    orderdDictionary.Add("4", 2);
    orderdDictionary.Add("3", 3);
    orderdDictionary.Add("2", 4);
    orderdDictionary.Add("1", 5);
    orderdDictionary.Add("6", 0);
    var num = orderdDictionary.GetEnumerator();
    while (num.MoveNext())
    {
        Console.WriteLine(num.Key + " : " + num.Value);
    }
}
bool IsSubsequence(string s, string t)
{
    var sa = SplitString(s);
    var ta = SplitString(t);
    Dictionary<string, int> sdic = new Dictionary<string, int>();
    for (int z = 0; z < sa.Count(); z++)
    {
        sdic.Add(sa[z] + z, z);
    }
    int i = 0;
    for (int j = 0; j < ta.Count(); j++)
    {
        int check;
        if (sdic.TryGetValue(ta[j] + i, out check))
        {
            if (ta[j] == sa[i])
            {
                i++;
            }
            else
                return false;
        }
    }
    if (i == sa.Count())
        return true;
    else
        return false;
}
bool IsIsomorphic(string s, string t)
{
    var sa = SplitString(s);
    var ta = SplitString(t);
    if (sa.Count() != ta.Count())
    {
        return false;
    }
    Dictionary<string, int> sdic = new Dictionary<string, int>();
    Dictionary<string, int> tdic = new Dictionary<string, int>();
    int i = 0;
    while (i < sa.Count())
    {
        int check;
        var sexists = sdic.TryGetValue(sa[i], out check);
        var texists = tdic.TryGetValue(ta[i], out check);
        if (sexists != texists)
        {
            return false;
        }
        if (sexists)
        {
            int indexs = sdic[sa[i]];
            int indext = tdic[ta[i]];
            if (indexs != indext)
            {
                return false;
            }
            sdic[sa[i]] = i;
            tdic[ta[i]] = i;
        }
        else
        {
            sdic.Add(sa[i], i);
            tdic.Add(ta[i], i);
        }
        i++;
    }
    return true;
}
int MyAtoi(string s)
{
    bool isNegative = false;
    bool isPositive = false;
    int result = 0;
    string numstr = "";
    while (s.Length > 0)
    {
        string chr = s.Substring(0, 1);
        s = s.Substring(1, s.Length - 1);
        if (chr == " ")
        {
            if (isPositive || isNegative)
                break;
            continue;
        }
        else if (chr == "+")
        {
            if (isNegative || isPositive)
                break;
            isPositive = true;
        }
        else if (chr == "-")
        {
            if (isNegative || isPositive)
                break;
            isNegative = true;
        }
        else if (int.TryParse(chr, out int numericValue))
        {
            isPositive = true;
            numstr = numstr + chr;
        }
        else
        {
            break;
        }
    }
    if (numstr.Length > 0)
    {
        Double temp = Convert.ToDouble(numstr);
        if (isNegative)
        {
            temp = temp * -1;
            if (temp <= -2147483648)
            {
                result = -2147483648;
            }
            else
            {
                result = Convert.ToInt32(numstr) * -1;
            }
        }
        else
        {
            if (temp >= 2147483647)
            {
                result = 2147483647;
            }
            else
            {
                result = Convert.ToInt32(numstr);
            }
        }
    }
    return result;
}
int Reverse(int x)
{
    if (x > 2147483647 || x < -2147483647)
        return 0;
    if (x > -10 && x < 10)
        return x;
    bool nonNegative = true;
    if (x < 0)
        nonNegative = false;
    string xstr = Convert.ToString(x);
    if (!nonNegative)
        xstr = xstr.Substring(1, xstr.Length - 1);
    List<string> xlist = SplitString(xstr);
    string ystr = JoinString(xlist);
    var y = Convert.ToDouble(ystr);
    if (y > 2147483647 || y < -2147483647)
        return 0;
    int z = Convert.ToInt32(ystr);
    if (!nonNegative)
        z = z * -1;
    return z;
}
int MaxArea(int[] height)
{
    int area = 0;
    int j = height.Count() - 1;
    int i = 0;
    while (i != j)
    {
        int temp = Math.Min(height[i], height[j]) * (j - i);
        if (temp > area)
            area = temp;
        if (height[i] > height[j])
            j--;
        else
            i++;
    }
    return area;
}
bool ContainsNearbyDuplicate(int[] nums, int k)
{
    Dictionary<int, int> dic = new Dictionary<int, int>();
    for (int i = 0; i < nums.Count(); i++)
    {
        int check;
        if (dic.TryGetValue(nums[i], out check))
        {
            int diff = i - dic[nums[i]];
            if (diff <= k)
            {
                return true;
            }
            else if (diff > k)
            {
                dic[nums[i]] = i;
            }
        }
        else
        {
            dic.Add(nums[i], i);
        }
    }
    return false;
}
int[] PlusOne(int[] digits)
{
    Stack<int> stack = new Stack<int>();
    int n = digits[digits.Length - 1] + 1;
    int reminder = 0;
    if (n > 9)
    {
        reminder = 1;
        stack.Push(0);
    }
    else
    {
        stack.Push(n);
    }
    for (int i = digits.Count() - 2; i > -1; i--)
    {
        n = digits[i] + reminder;
        reminder = 0;
        if (n > 9)
        {
            reminder = 1;
            stack.Push(0);
        }
        else
        {
            stack.Push(n);
        }
    }
    if (reminder > 0)
        stack.Push(reminder);
    int[] res = new int[stack.Count];
    int index = 0;
    while (stack.Count > 0)
    {
        res[index] = stack.Pop();
        index++;
    }
    return res;
}
bool ContainsDuplicate(int[] nums)
{
    Dictionary<int, int> dictionary = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++)
    {
        int duplicate;
        if (!dictionary.TryGetValue(nums[i], out duplicate))
        {
            dictionary.Add(nums[i], nums[i]);
        }
        else
        {
            return true;
        }
    }
    return false;
}
bool IsPalindrome(int x)
{
    bool result = true;
    ArrayList arr = new ArrayList();
    if (x < 0)
    {
        return false;
    }
    else if (x >= 0 && x < 10)
    {
        return true;
    }
    else if (x % 10 == 0)
    {
        return false;
    }
    else
    {
        int baseNum = 10;
        while (x != 0)
        {
            if (x < baseNum)
            {
                arr.Add((int)(x));
                x = 0;
            }
            else
            {
                int rem = x % baseNum;
                arr.Add((int)(rem));
                x = (x - rem) / 10;
            }
        }
        int j = arr.Count - 1;
        for (int i = 0; i < arr.Count - 1; i++)
        {
            if (i == j)
                break;
            if ((int)arr[i] != (int)arr[j])
            {
                result = false;
                break;
            }
            j--;
        }
        return result;
    }
}
int[] RunningSum(int[] nums)
{
    int sum = 0;
    for (int i = 0; i < nums.Count(); i++)
    {
        sum = sum + nums[i];
        nums[i] = sum;
    }
    return nums;
}
int PivotIndex(int[] nums)
{
    int sum = 0;
    for (int i = 0; i < nums.Count(); i++)
    {
        sum = sum + nums[i];
    }
    int leftSum = 0;
    for (int j = 0; j < nums.Count(); j++)
    {
        if (sum - leftSum - nums[j] == leftSum)
            return j;
        else
            leftSum = leftSum + nums[j];
    }
    return -1;
}
int RemoveDuplicates(int[] nums)
{
    Dictionary<int, int> dictionary = new Dictionary<int, int>();
    int marker = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        int duplicate;
        if (!dictionary.TryGetValue(nums[i], out duplicate))
        {
            nums[marker] = nums[i];
            marker++;
            dictionary.Add(nums[i], nums[i]);
        }
    }
    return marker;
}
#endregion Problems

#region Helpers

string NumberToSymbol(int n, int num, string replacement, out int reminder, string response)
{
    reminder = num % n;
    num = num - reminder;
    for (int i = 0; i < num / n; i++)
    {
        response = response + replacement;
    }
    return response;
}
ListNode ListToLinkList(List<int> input)
{
    ListNode result = null;
    for (int i = input.Count - 1; i >= 0; i--)
    {
        if (result == null)
        {
            result = new ListNode();
            result.val = input[i];

        }
        else
        {
            ListNode node = new ListNode();
            node.val = input[i];
            node.next = result;
            result = node;
        }

    }
    return result;
}
string JoinString(List<string> input)
{
    StringBuilder result = new StringBuilder();
    for (int i = input.Count() - 1; i >= 0; i--)
    {
        result.Append(input[i]);
    }
    return result.ToString();
}
List<string> SplitString(string input)
{
    List<string> result = new List<string>();
    while (input.Length > 0)
    {
        result.Add(input.Substring(0, 1));
        input = input.Substring(1, input.Length - 1);
    }
    return result;

}
#endregion Helpers

//*Definition for singly - linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
