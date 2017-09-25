using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public static class BindingSourceExtension
    {
        public static void MoveUp(this BindingSource aBindingSource)
        {
            int position = aBindingSource.Position;
            if (position == -1) return;
            if (position == 0) return;  // already at top

            aBindingSource.RaiseListChangedEvents = false;

            object current = aBindingSource.Current;
            aBindingSource.Remove(current);

            position--;

            aBindingSource.Insert(position, current);
            aBindingSource.Position = position;

            aBindingSource.RaiseListChangedEvents = true;
            aBindingSource.ResetBindings(false);
        }

        public static void MoveDown(this BindingSource aBindingSource)
        {
            int position = aBindingSource.Position;
            if (position == aBindingSource.Count - 1) return;  // already at bottom

            aBindingSource.RaiseListChangedEvents = false;

            object current = aBindingSource.Current;
            aBindingSource.Remove(current);

            position++;

            aBindingSource.Insert(position, current);
            aBindingSource.Position = position;

            aBindingSource.RaiseListChangedEvents = true;
            aBindingSource.ResetBindings(false);
        }

        public static void Delete(this BindingSource aBindingSource)
        {
            aBindingSource.Remove(aBindingSource.Current);
        }

        public static void Insert(this BindingSource aBindingSource, object aBindingSourseInsertingData)
        {
            int position = aBindingSource.Position;
            if (position == -1)
            {
                aBindingSource.Insert(aBindingSource.Count, aBindingSourseInsertingData);
            }
            else
            {
                aBindingSource.Insert(aBindingSource.Position, aBindingSourseInsertingData);
            }

        }

        public static object GetDataSource(this BindingSource aBindingSource)
        {
            return aBindingSource.DataSource;
            // Attention after return DataSource up I need to convert my List back to sourse List!!!! 
            //humans = BindingSourceExtension.Save(bs) as List<Human>; // this is nessesary row. This sentence convert object list to my list, after some operations! 
            // I think this peace of code I need to put in try - catch block !!!
        }
    }

}
