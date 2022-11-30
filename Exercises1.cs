///<summary>
///<author>Branium Academy</author>
///<seealso cref="Trang chủ" href="https://braniumacademy.net"/>
///<version>2022.06.08</version>
///</summary>

using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesLesson104
{
    class Exercises1
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            LinkedList<string> list = new LinkedList<string>();
            int choice = 0;
            do
            {
                Console.WriteLine("==================== MENU ====================");
                Console.WriteLine("01. Thêm node vào đầu danh sách liên kết.");
                Console.WriteLine("02. Thêm node vào cuối danh sách liên kết.");
                Console.WriteLine("03. Thêm node vào sau node có giá trị x.");
                Console.WriteLine("04. Thêm node vào sau vị trí k.");
                Console.WriteLine("05. Cập nhật node đầu tiên có giá trị x.");
                Console.WriteLine("06. Xóa node đầu tiên có giá trị x.");
                Console.WriteLine("07. Sắp xếp các phần tử trong danh sách liên kết.");
                Console.WriteLine("08. Xóa node đầu danh sách.");
                Console.WriteLine("09. Xóa node cuối danh sách.");
                Console.WriteLine("10. Trộn hai danh sách đã sắp xếp.");
                Console.WriteLine("11. Hiển thị các phần tử trong danh sách.");
                Console.WriteLine("12. Kết thúc chương trình.");
                Console.WriteLine("==> Bạn chọn chức năng số? ");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Nhập một từ: ");
                        var data = Console.ReadLine();
                        list.AddFirst(data);
                        break;
                    case 2:
                        Console.WriteLine("Nhập một từ: ");
                        data = Console.ReadLine();
                        list.AddLast(data);
                        break;
                    case 3:
                        Console.WriteLine("Nhập node có giá trị x: ");
                        var x = Console.ReadLine();
                        Console.WriteLine("Nhập từ cần thêm: ");
                        data = Console.ReadLine();
                        list.AddAfterX(data, x);
                        break;
                    case 4:
                        Console.WriteLine("Nhập vị trí k: ");
                        int k = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhập từ cần thêm: ");
                        data = Console.ReadLine();
                        list.AddAtPosition(data, k);
                        break;
                    case 5:
                        Console.WriteLine("Nhập giá trị x: ");
                        x = Console.ReadLine();
                        Console.WriteLine("Nhập giá trị thay thế: ");
                        data = Console.ReadLine();
                        list.Update(x, data);
                        break;
                    case 6:
                        Console.WriteLine("Nhập giá trị node cần xóa: ");
                        x = Console.ReadLine();
                        if(list.RemoveFirstX(x))
                        {
                            Console.WriteLine("==> Xóa thành công. <==");
                        } else
                        {
                            Console.WriteLine("==> Xóa thất bại. <==");
                        }
                        break;
                    case 7:
                        list.Sort();
                        break;
                    case 8:
                        if (list.RemoveFirst())
                        {
                            Console.WriteLine("==> Xóa thành công. <==");
                        }
                        else
                        {
                            Console.WriteLine("==> Xóa thất bại. <==");
                        }
                        break;
                    case 9:
                        if (list.RemoveLast())
                        {
                            Console.WriteLine("==> Xóa thành công. <==");
                        }
                        else
                        {
                            Console.WriteLine("==> Xóa thất bại. <==");
                        }
                        break;
                    case 10:
                        var result = list.Merge(list);
                        Console.WriteLine("Danh sách mới sau khi trộn: ");
                        result.ShowNodes();
                        break;
                    case 11:
                        Console.WriteLine("Các phần tử của danh sách: ");
                        list.ShowNodes();
                        break;
                    case 12:
                        Console.WriteLine("==> Chương trình kết thúc. <==");
                        break;
                    default:
                        Console.WriteLine("==> Sai chức năng. Vui lòng chọn lại. <==");
                        break;
                }
            } while (choice != 12);

        }
    }

    class LinkedList<T> where T : IComparable<T>
    {
        public Node<T> First { get; set; }
        public Node<T> Last { get; set; }

        public LinkedList()
        {
            First = null;
            Last = null;
        }

        // thêm node vào đầu danh sách lk
        public void AddFirst(T data)
        {
            var newNode = new Node<T>(data);
            if (IsEmpty())
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                newNode.Next = First;
                First = newNode;
            }
        }

        // thêm node vào cuối danh sách lk
        public void AddLast(T data)
        {
            var newNode = new Node<T>(data);
            if (IsEmpty())
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }
        }

        // thêm node vào sau node x danh sách lk
        public void AddAfterX(T data, T x)
        {
            if (IsEmpty())
            {
                AddFirst(data);
            }
            else
            {
                var currentNode = First;
                while (currentNode != null)
                {
                    if (currentNode.Data.Equals(x))
                    {
                        if (currentNode == Last)
                        {
                            AddLast(data);
                        }
                        else
                        {
                            var newNode = new Node<T>(data);
                            newNode.Next = currentNode.Next;
                            currentNode.Next = newNode;
                        }
                        break;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }

        // thêm node vào sau node thứ k(tính từ 1)
        public void AddAtPosition(T data, int k)
        {
            if (IsEmpty() || k <= 0)
            {
                AddFirst(data);
            }
            else
            {
                int counter = 1;
                var currentNode = First;
                while (currentNode != null)
                {
                    if (counter == k)
                    {
                        if (currentNode == Last)
                        {
                            AddLast(data);
                        }
                        else
                        {
                            var newNode = new Node<T>(data);
                            newNode.Next = currentNode.Next;
                            currentNode.Next = newNode;
                        }
                        break;
                    }
                    counter++;
                    currentNode = currentNode.Next;
                }
                // nếu duyệt hết mà chưa đủ k phần tử, chèn vào cuối danh sách
                if(counter < k)
                {
                    AddLast(data);
                }
            }
        }

        // cập nhật node đầu tiên có giá trị x
        public bool Update(T x, T newData)
        {
            if (IsEmpty()) // không có gì để cập nhật
            {
                return false; // cập nhật thất bại
            }
            else
            {
                var currentNode = First;
                while (currentNode != null) // tìm node để cập nhật
                {
                    if (currentNode.Data.CompareTo(x) == 0) // tìm thấy
                    {
                        currentNode.Data = newData; // cập nhật giá trị node x
                        return true; // thông báo cập nhật thành công
                    }
                    currentNode = currentNode.Next;
                }
                return false; // không tìm thấy node cần cập nhật
            }
        }

        // xóa node đầu tiên có giá trị x
        public bool RemoveFirstX(T x)
        {
            if (IsEmpty()) // không có gì để xóa
            {
                return false; // xóa thất bại
            }
            else
            {
                var currentNode = First;
                var prevNode = currentNode;
                while (currentNode != null) // tìm node để xóa
                {
                    if (currentNode.Data.CompareTo(x) == 0) // tìm thấy
                    {
                        if (currentNode.Equals(First))
                        {
                            return RemoveFirst();
                        }
                        else if (currentNode.Equals(Last))
                        {
                            return RemoveLast();
                        }
                        else
                        {
                            prevNode.Next = currentNode.Next;
                            currentNode.Next = null;
                            return true;
                        }
                    }
                    prevNode = currentNode;
                    currentNode = currentNode.Next;
                }
                return false; // không tìm thấy node cần xóa
            }
        }

        // sắp xếp các phần tử trong danh sách liên kết theo thứ tự từ điển
        public void Sort()
        {
            for (Node<T> p = First; p != null; p = p.Next)
            {
                for (Node<T> q = p.Next; q != null; q = q.Next)
                {
                    if (p.Data.CompareTo(q.Data) > 0)
                    {
                        var tmp = p.Data;
                        p.Data = q.Data;
                        q.Data = tmp;
                    }
                }
            }
        }

        // xóa node đầu tiên trong danh sách
        public bool RemoveFirst()
        {
            if (IsEmpty())
            {
                return false;
            }
            else
            {
                if(First.Equals(Last))
                {
                    First = Last = null;
                }
                else
                {
                    var removedNode = First;
                    First = First.Next;
                }
                return true;
            }
        }

        // xóa node cuối danh sách
        public bool RemoveLast()
        {
            if (IsEmpty())
            {
                return false;
            }
            else
            {
                if(First.Equals(Last))
                {
                    First = Last = null;
                } else
                {
                    var currentNode = First;
                    var prevNode = currentNode;
                    while (currentNode != Last)
                    {
                        prevNode = currentNode;
                        currentNode = currentNode.Next;
                    }
                    Last = prevNode;
                }
                return true;
            }
        }

        // trộn hai danh sách liên kết
        public LinkedList<T> Merge(LinkedList<T> other)
        {
            Sort();
            other.Sort();
            LinkedList<T> result = new LinkedList<T>();
            Node<T> first = First; // cho first tham chiếu tới đầu danh sách thứ 1
            Node<T> second = other.First; // cho second tham chiếu tới đầu danh sách thứ 2
            while (first != null && second != null) // nếu cả hai danh sách cùng chưa xét hết
            {
                if (first.Data.CompareTo(second.Data) < 0) // node đang xét của danh sách 1 nhỏ hơn
                {
                    result.AddLast(first.Data); // lấy node này cho vào danh sách kết quả
                    first = first.Next;
                }
                else // node đang xét của danh sách 2 nhỏ hơn hoặc bằng node đang xét ở danh sách 1
                {
                    result.AddLast(second.Data); // lấy node này cho vào danh sách kết quả
                    second = second.Next;
                }
            }
            // nếu danh sách 1 chưa xét hết, lấy nốt các phần tử còn lại
            while (first != null)
            {
                result.AddLast(first.Data);
                first = first.Next;
            }
            // nếu danh sách 2 chưa xét hết, lấy nốt các phần tử còn lại
            while (second != null)
            {
                result.AddLast(second.Data);
                second = second.Next;
            }
            return result;
        }

        // kiểm tra danh sách rỗng
        public bool IsEmpty()
        {
            return First == null && Last == null;
        }

        // hiển thị danh sách các node hiện có
        public void ShowNodes()
        {
            var x = First;
            while (x != null)
            {
                Console.Write($"{x.Data} -> ");
                x = x.Next;
            }
            Console.WriteLine("null");
        }
    }

    class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node()
        {
            Next = null;
        }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }

        public override bool Equals(object obj)
        {
            return obj is Node<T> node &&
                   EqualityComparer<T>.Default.Equals(Data, node.Data);
        }

        public override int GetHashCode()
        {
            return -301143667 + EqualityComparer<T>.Default.GetHashCode(Data);
        }
    }
}
