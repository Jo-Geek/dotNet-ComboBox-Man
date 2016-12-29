using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ComboBoxMan
{
  /// <summary>
  ///     A pack of functions to help with manipulating and adding a list of items with 'text' and 'value' in a System.Windows.Forms.ComboBox
  /// </summary>
  /// <remarks>
  ///     
  /// </remarks>
  public class ComboBoxData
  {
    #region decalarations
    private DataTable dt = new DataTable("ComboBoxList");
    private DataRow xRow;
    private DataTable dtPreserve = new DataTable("PreservedComboList");
    #endregion

    /// <summary>
    ///     various options to fill a comboBox with data
    /// </summary>
    public enum FillOptions
    {
      /// <summary>
      ///     preserve the existing items in the combobox
      /// </summary>
      preserveExisting = 0,
      /// <summary>
      ///     overwrite the existing items in the comboBox
      /// </summary>
      overwriteExisting = 1
    }

    /// <summary>
    ///     Initialize a class to add comboBoxItems
    /// </summary>
    public ComboBoxData()
    {
      dt.Columns.Add(new DataColumn("Value"));
      dt.Columns.Add(new DataColumn("Text"));

      dtPreserve.Columns.Add(new DataColumn("Value"));
      dtPreserve.Columns.Add(new DataColumn("Text"));
    }

    /// <summary>
    ///     Initialize class with one item 
    /// </summary>
    /// <param name="text" type="String">
    ///     <para>
    ///         Text member of the item
    ///     </para>
    /// </param>
    public ComboBoxData(string text)
    {
      dtPreserve.Columns.Add(new DataColumn("Value"));
      dtPreserve.Columns.Add(new DataColumn("Text"));
      dt.Columns.Add(new DataColumn("Value"));
      dt.Columns.Add(new DataColumn("Text"));
      xRow = dt.NewRow();
      xRow["Value"] = text;
      xRow["Text"] = text;
      dt.Rows.Add(xRow);
    }

    /// <summary>
    ///     Initialize class with text and value of first item
    /// </summary>
    /// <param name="text" type="String">
    ///     <para>
    ///         Text member of the item
    ///     </para>
    /// </param>
    /// <param name="value" type="Object">
    ///     <para>
    ///         Value member of the item
    ///     </para>
    /// </param>
    public ComboBoxData(string text, object value)
    {
      dtPreserve.Columns.Add(new DataColumn("Value"));
      dtPreserve.Columns.Add(new DataColumn("Text"));
      dt.Columns.Add(new DataColumn("Value"));
      dt.Columns.Add(new DataColumn("Text"));
      xRow = dt.NewRow();
      xRow["Value"] = value;
      xRow["Text"] = text;
      dt.Rows.Add(xRow);
    }

    /// <summary>
    ///     Add an item to the list, returns true if item added
    /// </summary>
    /// <param name="text" type="String">
    ///     <para>
    ///         Text member of the item
    ///     </para>
    /// </param>
    /// <param name="value" type="Object">
    ///     <para>
    ///         Value member of the item
    ///     </para>
    /// </param>
    public void add(string text, object value)
    {
      try
      {
        xRow = dt.NewRow();
        xRow["Value"] = value;
        xRow["Text"] = text;
        dt.Rows.Add(xRow);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    ///     Add an item to the list with same value and text, returns true if item added
    /// </summary>
    /// <param name="text" type="String">
    ///     <para>
    ///         Text member of the item
    ///     </para>
    /// </param>
    public void add(string text)
    {
      try
      {
        xRow = dt.NewRow();
        xRow["Value"] = text;
        xRow["Text"] = text;
        dt.Rows.Add(xRow);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    ///     merge a datatable of values with the existing items in this object
    /// </summary>
    /// <param name="dt" type="System.Data.DataTable">
    ///     <para>
    ///         the datatable to merge
    ///     </para>
    /// </param>
    /// <param name="TextColumnName" >
    ///     <para>
    ///         the name of the column containing the 'text' member
    ///     </para>
    /// </param>
    /// <param name="ValueColumnName" >
    ///     <para>
    ///         the name of the column containing the 'value' member
    ///     </para>
    /// </param>    
    public void add(DataTable dtMerge, string TextColumnName, string ValueColumnName)
    {
      try
      {
        foreach (DataRow item in dtMerge.Rows)
        {
          DataRow xRow = dt.NewRow();
          xRow["Text"] = item[TextColumnName];
          xRow["Value"] = item[ValueColumnName];

          dt.Rows.Add(xRow);
        }

        dt.AcceptChanges();

      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    ///     merge a datatable of values with the existing items in this object
    /// </summary>
    /// <param name="dt" type="System.Data.DataTable">
    ///     <para>
    ///         the datatable to merge
    ///     </para>
    /// </param>
    /// <param name="TextColumnIndex" >
    ///     <para>
    ///         the zero based index of the column containing the 'text' member
    ///     </para>
    /// </param>
    /// <param name="ValueColumnIndex" >
    ///     <para>
    ///         the zero based index of the column containing the 'value' member
    ///     </para>
    /// </param>    
    public void add(DataTable dtMerge, string TextColumnIndex, string ValueColumnIndex)
    {
      try
      {
        foreach (DataRow item in dtMerge.Rows)
        {
          DataRow xRow = dt.NewRow();
          xRow["Text"] = item[TextColumnIndex];
          xRow["Value"] = item[ValueColumnIndex];

          dt.Rows.Add(xRow);
        }

        dt.AcceptChanges();

      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    ///     Get the List as a DataTable of two columns 'Value' and 'Text'
    /// </summary>
    /// <returns>
    ///     A System.Data.DataTable ...
    /// </returns>
    public DataTable getData()
    {
      dt.AcceptChanges();
      return dt;
    }

    /// <summary>
    ///     Fills the ComboBox with the items in current object, This makes the comboBox DataBound.
    /// </summary>
    /// <param name="xCmb" type="System.Windows.Forms.ComboBox">
    ///     <para>
    ///         the ComboBox to fill
    ///     </para>
    /// </param>
    /// <param name="xPreserve" type="Boolean">
    ///     <para>
    ///         a boolean to indicate if previous values should be preserved. Note that only the 'text' will be preserved in both 'text' and 'value' fields.
    ///     </para>
    /// </param>
    public void Fill(ComboBox xCmb, FillOptions xOpt = FillOptions.overwriteExisting)
    {
      try
      {
        if (dt.Rows.Count == 0)
        {
          throw new ArgumentException("There are no items in the list to Fill, Add items to the list before filling a control");
        }
        else
        {
          if ((xCmb) is ComboBox)
          {

            if (xOpt == FillOptions.preserveExisting)
            {
              if (xCmb.Items.Count > 0)
              {
                dtPreserve.Clear();
                for (int i = 0; i < xCmb.Items.Count; i++)
                {
                  DataRow xRow = dtPreserve.NewRow();
                  xRow["Text"] = xCmb.Items[i].ToString();
                  xRow["Value"] = xCmb.Items[i].ToString();
                  dtPreserve.Rows.Add(xRow);
                }
                dtPreserve.AcceptChanges();
                dtPreserve.Merge(dt, true, MissingSchemaAction.Error);
                xCmb.DisplayMember = "Text";
                xCmb.ValueMember = "Value";
                xCmb.DataSource = dtPreserve;
              }
              else
              {
                xCmb.DisplayMember = "Text";
                xCmb.ValueMember = "Value";
                xCmb.DataSource = dt;
              }
            }
            else
            {
              xCmb.DisplayMember = "Text";
              xCmb.ValueMember = "Value";
              xCmb.DataSource = dt;
            }
          }
          else
          {
            throw new ArgumentException("Ivalid control was passed to fill the list");
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    ///     Removes all the items from this object
    /// </summary>
    public void reset()
    {
      dt.Reset();
    }

    /// <summary>
    ///     Get the text at specified index
    /// </summary>
    /// <param name="Index" type="Integer">
    ///     <para>
    ///         index of the item
    ///     </para>
    /// </param>
    /// <returns>
    ///     A String value at the specified index...
    /// </returns>
    public string getText(int Index)
    {
      try
      {
        return dt.Rows[Index]["Text"].ToString();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    ///     Get the value at specified index
    /// </summary>
    /// <param name="Index" type="Integer">
    ///     <para>
    ///         index of the item
    ///     </para>
    /// </param>
    /// <returns>
    ///     A String value...
    /// </returns>
    public object getValue(int Index)
    {
      try
      {
        return dt.Rows[Index]["Value"];
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    ///     Set text to a specific index in the list
    /// </summary>
    /// <param name="Index" type="int">
    ///     <para>
    ///         the zero based index of the text to be replaced
    ///     </para>
    /// </param>
    /// <param name="text" type="string">
    ///     <para>
    ///         the text to be inserted in the list
    ///     </para>
    /// </param>
    public void setText(int Index,string text)
    {
      try
      {
        dt.Rows[Index]["Text"] = text;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    ///     set the value of a specified index in the list
    /// </summary>
    /// <param name="Index" type="int">
    ///     <para>
    ///         the zero based index of the value to be replaced
    ///     </para>
    /// </param>
    /// <param name="value" type="object">
    ///     <para>
    ///         the value to be inserted in the list
    ///     </para>
    /// </param>
    public void setValue(int Index, object value)
    {
      try
      {
        dt.Rows[Index]["Value"] = value;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    ///     set the value and text of a specified index in the list
    /// </summary>
    /// <param name="Index" type="int">
    ///     <para>
    ///         the zero based index of the value to be replaced
    ///     </para>
    /// </param>
    /// <param name="value" type="object">
    ///     <para>
    ///         the value to be inserted in the list
    ///     </para>
    /// </param>
    /// <param name="text">
    ///     <para>
    ///         the text to be inserted in the list
    ///     </para>
    /// </param>
    public void setValue(int Index, string text, object value)
    {
      try
      {
        dt.Rows[Index]["Value"] = value;
        dt.Rows[Index]["Text"] = text;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
