using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WkRec.Entities
{
    public class WorkingTaskCollection : IList<WorkingTask>
    {
        // 非公開プロパティ

        private List<WorkingTask> _items;


        // コンストラクタ

        public WorkingTaskCollection()
        {
            this._items = new List<WorkingTask>();
        }



        // 公開プロパティ

        public WorkingTask this[int index]
        {
            get => ((IList<WorkingTask>)_items)[index];
            set => ((IList<WorkingTask>)_items)[index] = value;
        }

        public int Count
        {
            get => ((ICollection<WorkingTask>)_items).Count;
        }

        public bool IsReadOnly
        {
            get => ((ICollection<WorkingTask>) _items).IsReadOnly;
        }

        public void Add(WorkingTask item)
        {
            ((ICollection<WorkingTask>)_items).Add(item);
        }

        public void Clear()
        {
            ((ICollection<WorkingTask>)_items).Clear();
        }

        public bool Contains(WorkingTask item)
        {
            return ((ICollection<WorkingTask>)_items).Contains(item);
        }

        public void CopyTo(WorkingTask[] array, int arrayIndex)
        {
            ((ICollection<WorkingTask>)_items).CopyTo(array, arrayIndex);
        }

        public IEnumerator<WorkingTask> GetEnumerator()
        {
            return ((IEnumerable<WorkingTask>)_items).GetEnumerator();
        }

        public int IndexOf(WorkingTask item)
        {
            return ((IList<WorkingTask>)_items).IndexOf(item);
        }

        public void Insert(int index, WorkingTask item)
        {
            ((IList<WorkingTask>)_items).Insert(index, item);
        }

        public bool Remove(WorkingTask item)
        {
            return ((ICollection<WorkingTask>)_items).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<WorkingTask>)_items).RemoveAt(index);
        }

        public void AddRange(IEnumerable<WorkingTask> collection)
        {
            this._items.AddRange(collection);
        }

        public IEnumerable<WorkingTask> FindBy(WorkingTaskSource source)
        {
            return this._items.Where(item => item.TaskSourceIdentifier.Equals(source.Identifier));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_items).GetEnumerator();
        }
    }
}
