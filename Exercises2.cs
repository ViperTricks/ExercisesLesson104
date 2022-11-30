///<summary>
///<author>Branium Academy</author>
///<seealso cref="Trang chủ" href="https://braniumacademy.net"/>
///<version>2022.06.08</version>
///</summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExercisesLesson104
{
    class Exercises2
    {
        // tạo mới sinh viên từ thông tin nhập vào từ bàn phím
        static Student CreateStudent()
        {
            Console.WriteLine("==> Nhập thông tin sinh viên: ");
            Console.WriteLine("Mã sinh viên: ");
            var id = Console.ReadLine().ToUpper();
            Console.WriteLine("Họ và tên: ");
            var name = Console.ReadLine();
            Console.WriteLine("Địa chỉ: ");
            var address = Console.ReadLine();
            Console.WriteLine("Tuổi: ");
            var age = int.Parse(Console.ReadLine());
            Console.WriteLine("Điểm TB: ");
            var gpa = float.Parse(Console.ReadLine());
            return new Student(id, name, address, age, gpa);
        }

        // tìm sinh viên theo mã sinh viên
        static Student FindById(LinkedList<Student> list, string id)
        {
            var item = list.First;
            while (item != null)
            {
                if (item.Data.Id.CompareTo(id) == 0)
                {
                    return item.Data;
                }
                item = item.Next;
            }
            return null;
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            LinkedList<Student> list = new LinkedList<Student>();
            int choice;
            do
            {
                Console.WriteLine("==================== MENU ====================");
                Console.WriteLine("01. Thêm sinh viên vào đầu danh sách liên kết.");
                Console.WriteLine("02. Thêm sinh viên vào cuối danh sách liên kết.");
                Console.WriteLine("03. Thêm sinh viên vào sau sinh viên có mã x.");
                Console.WriteLine("04. Cập nhật điểm cho sinh viên mã x.");
                Console.WriteLine("05. Tìm sinh viên có mã x.");
                Console.WriteLine("06. Xóa sinh viên đầu tiên khỏi danh sách.");
                Console.WriteLine("07. Xóa sinh viên cuối khỏi danh sách.");
                Console.WriteLine("08. Xóa sinh viên có mã x khỏi danh sách.");
                Console.WriteLine("09. Xóa tất cả sinh viên có điểm tb bằng x.");
                Console.WriteLine("10. Liệt kê các sinh viên có địa chỉ x.");
                Console.WriteLine("11. Sắp xếp các sinh viên trong danh sách.");
                Console.WriteLine("12. Liệt kê các sinh viên có điểm TB  >= x.");
                Console.WriteLine("13. Hiển thị danh sách sinh viên ra màn hình.");
                Console.WriteLine("14. Kết thúc chương trình.");
                Console.WriteLine("==> Bạn chọn chức năng số? ");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        var student = CreateStudent();
                        list.AddFirst(student);
                        break;
                    case 2:
                        student = CreateStudent();
                        list.AddLast(student);
                        break;
                    case 3:
                        Console.WriteLine("Nhập mã sinh viên liền trước: ");
                        var x = Console.ReadLine().ToUpper();
                        student = CreateStudent();
                        var studentX = new Student(x);
                        list.AddAfterX(student, studentX);
                        break;
                    case 4:
                        if (!list.IsEmpty())
                        {
                            Console.WriteLine("Nhập mã sinh viên: ");
                            var id = Console.ReadLine().ToUpper();
                            Console.WriteLine("Nhập điểm thay thế: ");
                            var newGpa = float.Parse(Console.ReadLine());
                            studentX = FindById(list, id);
                            if (studentX != null)
                            {
                                studentX.Gpa = newGpa;
                                list.Update(studentX);
                                Console.WriteLine("==> Cập nhật điểm cho sinh viên thành công. <==");
                            }
                            else
                            {
                                Console.WriteLine("==> Sinh viên cần cập nhật không tồn tại.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách rỗng. <==");
                        }
                        
                        break;
                    case 5:
                        if (!list.IsEmpty())
                        {
                            Console.WriteLine("Nhập mã sinh viên: ");
                            var id = Console.ReadLine().ToUpper();
                            var targetStudent = FindById(list, id);
                            if (targetStudent != null)
                            {
                                Console.WriteLine($"==> Tìm thấy sinh viên mã '{id}' <==");
                                Console.WriteLine("Mã sinh viên: " + targetStudent.Id);
                                Console.WriteLine("Tên: " + targetStudent.FirstName);
                                Console.WriteLine("Địa chỉ: " + targetStudent.Address);
                                Console.WriteLine("Tuổi: " + targetStudent.Age);
                                Console.WriteLine("Điểm TB: " + targetStudent.Gpa);
                            }
                            else
                            {
                                Console.WriteLine("==> Không tìm thấy sinh viên cần tìm. <==");
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách rỗng. <==");
                        }
                        break;
                    case 6:
                        if (!list.IsEmpty())
                        {
                            if (list.RemoveFirst())
                            {
                                Console.WriteLine("==> Xóa thành công. <==");
                            }
                            else
                            {
                                Console.WriteLine("==> Xóa thất bại. <==");
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách rỗng. <==");
                        }
                        break;
                    case 7:
                        if (!list.IsEmpty())
                        {
                            if (list.RemoveLast())
                            {
                                Console.WriteLine("==> Xóa thành công. <==");
                            }
                            else
                            {
                                Console.WriteLine("==> Xóa thất bại. <==");
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách rỗng. <==");
                        }
                        
                        break;
                    case 8:
                        if (!list.IsEmpty())
                        {
                            Console.WriteLine("Nhập mã sinh viên: ");
                            var id = Console.ReadLine().ToUpper();
                            student = new Student(id);
                            if (list.RemoveFirstX(student))
                            {
                                Console.WriteLine("==> Xóa thành công. <==");
                            }
                            else
                            {
                                Console.WriteLine("==> Xóa thất bại. <==");
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách rỗng. <==");
                        }
                        break;
                    case 9:
                        if (!list.IsEmpty())
                        {
                            if (RemoveByGPA(list))
                            {
                                Console.WriteLine("==> Xóa thành công. <==");
                            }
                            else
                            {
                                Console.WriteLine("==> Xóa thất bại. <==");
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách rỗng. <==");
                        }
                        break;
                    case 10:
                        if (!list.IsEmpty())
                        {
                            var result = FindByAddress(list);
                            Console.WriteLine("Danh sách sinh viên tại địa chỉ cần tìm: ");
                            result.ShowNodes();
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách rỗng. <==");
                        }
                        break;
                    case 11:
                        if (!list.IsEmpty())
                        {
                            list.Sort();
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách rỗng. <==");
                        }
                        break;
                    case 12:
                        if (!list.IsEmpty())
                        {
                            var result = FindByGpa(list);
                            Console.WriteLine("Danh sách sinh viên tại địa chỉ cần tìm: ");
                            result.ShowNodes();
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách rỗng. <==");
                        }
                        break;
                    case 13:
                        if (!list.IsEmpty())
                        {
                            Console.WriteLine("Các sinh viên có trong danh sách: ");
                            list.ShowNodes();
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách rỗng. <==");
                        }
                        break;
                    case 14:
                        Console.WriteLine("==> Chương trình kết thúc. <==");
                        break;
                    default:
                        Console.WriteLine("==> Sai chức năng. Vui lòng chọn lại. <==");
                        break;
                }
            } while (choice != 14);
        }

        private static LinkedList<Student> FindByGpa(LinkedList<Student> list)
        {
            var result = new LinkedList<Student>();
            Console.WriteLine("Nhập mức điểm cần tìm hệ 4: ");
            var gpa = float.Parse(Console.ReadLine());
            var item = list.First;
            while (item != null)
            {
                if (item.Data.Gpa >= gpa)
                {
                    result.AddLast(item.Data);
                }
                item = item.Next;
            }
            return result;
        }

        private static LinkedList<Student> FindByAddress(LinkedList<Student> list)
        {
            var result = new LinkedList<Student>();
            Console.WriteLine("Địa chỉ cần tìm: ");
            var address = Console.ReadLine();
            var pattern = $".*{address}.*";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var item = list.First;
            while (item != null)
            {
                if (regex.IsMatch(item.Data.Address))
                {
                    result.AddLast(item.Data);
                }
                item = item.Next;
            }
            return result;
        }

        private static bool RemoveByGPA(LinkedList<Student> list)
        {
            Console.WriteLine("Nhập điểm của sinh viên cần xóa: ");
            var gpa = float.Parse(Console.ReadLine());
            var item = list.First;
            var isSuccess = false;
            while (item != null)
            {
                if (item.Data.Gpa == gpa)
                {
                    list.RemoveFirstX(item.Data);
                    isSuccess = true;
                }
                item = item.Next;
            }
            return isSuccess;
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
                if (counter < k)
                {
                    AddLast(data);
                }
            }
        }

        // cập nhật node đầu tiên có giá trị x
        public bool Update(T x)
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
                    if (currentNode.Data.Equals(x)) // tìm thấy
                    {
                        currentNode.Data = x; // cập nhật giá trị node x
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
                    if (currentNode.Data.Equals(x)) // tìm thấy
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
                } else
                {
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
                    return true;
                }
                var currentNode = First;
                var prevNode = currentNode;
                while (currentNode != Last)
                {
                    prevNode = currentNode;
                    currentNode = currentNode.Next;
                }
                Last = prevNode;
                Last.Next = null;
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
            var id = "Mã SV";
            var name = "Họ và tên";
            var address = "Địa chỉ";
            var age = "Tuổi";
            var gpa = "Điểm TB";
            Console.WriteLine($"{id,-15:d}{name,-25:d}{address,-20:d}{age,-10:d}{gpa,-10:d}");
            var x = First;
            while (x != null)
            {
                Console.WriteLine(x.Data);
                x = x.Next;
            }
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

    class Student : IComparable<Student>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public float Gpa { get; set; }

        public Student()
        {

        }

        public Student(string id)
        {
            Id = id;
        }

        public Student(string id, string fullName, string address, int age, float gpa)
        {
            SetName(fullName);
            Id = id;
            Address = address;
            Age = age;
            Gpa = gpa;
        }

        private void SetName(string fullName)
        {
            var data = fullName.Split(' ');
            FirstName = data[data.Length - 1];
            LastName = data[0];
            var midName = "";
            for (int i = 1; i < data.Length - 1; i++)
            {
                midName += data[i] + " ";
            }
            MidName = midName.Trim();
        }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                return -1;
            }
            else
            {
                if (Gpa > other.Gpa)
                {
                    return -1;
                }
                else if (Gpa < other.Gpa)
                {
                    return 1;
                }
                else
                {
                    int nameCompare = FirstName.CompareTo(other.FirstName);
                    if (nameCompare != 0)
                    {
                        return nameCompare;
                    }
                    else
                    {
                        return LastName.CompareTo(other.LastName);
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Id == student.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<string>.Default.GetHashCode(Id);
        }

        public override string ToString()
        {
            var fullName = $"{LastName} {MidName} {FirstName}";
            return $"{Id,-15:d}{fullName,-25:d}{Address,-20:d}{Age,-10:d}{Math.Round(Gpa, 2).ToString(),-10:d}";
        }
    }
}
