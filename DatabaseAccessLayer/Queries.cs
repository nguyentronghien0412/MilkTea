using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class Queries
    {
		#region Users

		public static string Users_GetByUsername(string UserName)
        {
            return @"select a.ID AS UserID, b.ID AS EmployeesID, a.UserName, a.Password, b.Code AS EmployeesCode, 
	                    FullName AS EmployeesName, c.Name AS Position, 
                        a.StatusID AS UserStatus, b.StatusID AS EmployeesStatus
                    from Users a, Employees b, Position c
                    where a.EmployeesID = b.ID
                    and b.PositionID = c.ID
                    and a.UserName = '" + UserName + @"'";
        }

        public static string Users_GetListPermission(string UserID)
        {
            string query;
            if (UserID == "")
            {
                query = @"select distinct b.*, c.PermissionGroupTypeID
                        from PermissionDetail a, Permission b, PermissionGroup c
                        where a.PermissionID = b.ID
                        and b.PermissionGroupID = c.ID";
            }
            else
            {
                query = @"select distinct info.*
                    from
                    (
	                    (
		                    select c.ID, c.Code, c.Name, d.PermissionGroupTypeID
		                    from UserAndPermissionDetail a, PermissionDetail b, Permission c, PermissionGroup d
		                    where a.PermissionDetailID = b.ID
		                    and b.PermissionID = c.ID
		                    and c.PermissionGroupID = d.ID
		                    and a.UserID = " + UserID + @"
	                    )
	                    union all
	                    (
		                    select d.ID, d.Code, d.Name, e.PermissionGroupTypeID
		                    from UserAndRole a, RoleDetail b, PermissionDetail c, Permission d, PermissionGroup e
		                    where a.RoleID = b.RoleID
		                    and b.PermissionDetailID = c.ID
		                    and c.PermissionID = d.ID
		                    and d.PermissionGroupID = e.ID
		                    and a.UserID = " + UserID + @"
	                    )
                    )info";
            }

            return query;
        }

        public static string Users_GetListPermissionDetail(string UserID)
        {
            string query;
            if (UserID == "")
            {
                query = @"select a.*, b.Code AS PermissionCode
                        from PermissionDetail a, Permission b, PermissionGroup c
                        where a.PermissionID = b.ID
                        and b.PermissionGroupID = c.ID";
            }
            else
            {
                query = @"select distinct info.*
                    from
                    (
	                    (
		                    select b.ID, b.Code, b.Name, b.PermissionID, c.Code AS PermissionCode
		                    from UserAndPermissionDetail a, PermissionDetail b, Permission c, PermissionGroup d
		                    where a.PermissionDetailID = b.ID
		                    and b.PermissionID = c.ID
		                    and c.PermissionGroupID = d.ID
		                    and a.UserID = " + UserID + @"
	                    )
	                    union all
	                    (
		                    select c.ID, c.Code, c.Name, c.PermissionID, d.Code AS PermissionCode
		                    from UserAndRole a, RoleDetail b, PermissionDetail c, Permission d, PermissionGroup e
		                    where a.RoleID = b.RoleID
		                    and b.PermissionDetailID = c.ID
		                    and c.PermissionID = d.ID
		                    and d.PermissionGroupID = e.ID
		                    and a.UserID = " + UserID + @"
	                    )
                    )info";
            }

            return query;
        }

        public static string Users_GetPermissionDetails(string UserID)
        {
            string query = @"(
                                SELECT DISTINCT e.Name COLLATE utf8_general_ci as Name, (e.ID + 0.4) as ID, 0 as ParentID, 
		                            '' AS CreatedByName, null as CreatedDate, e.ID AS MainID, 'PermissionGroupType' AS Type
                                FROM UserAndPermissionDetail a, PermissionDetail b, Permission c, PermissionGroup d, PermissionGroupType e, Users f, Employees g
                                WHERE a.PermissionDetailID = b.ID
                                AND b.PermissionID = c.ID
                                AND c.PermissionGroupID = d.ID
                                AND d.PermissionGroupTypeID = e.ID
                                AND a.CreatedBy = f.ID
                                AND f.EmployeesID = g.ID
                                AND a.UserID = " + UserID + @"
                            )
                            UNION ALL
                            (
                                SELECT DISTINCT d.Name COLLATE utf8_general_ci as Name, (d.ID + 0.3) as ID, (d.PermissionGroupTypeID + 0.4) as ParentID, 
		                            '' AS CreatedByName, null as CreatedDate, d.ID AS MainID, 'PermissionGroup' AS Type
                                FROM UserAndPermissionDetail a, PermissionDetail b, Permission c, PermissionGroup d, PermissionGroupType e, Users f, Employees g
                                WHERE a.PermissionDetailID = b.ID
                                AND b.PermissionID = c.ID
                                AND c.PermissionGroupID = d.ID
                                AND d.PermissionGroupTypeID = e.ID
                                AND a.CreatedBy = f.ID
                                AND f.EmployeesID = g.ID
                                AND a.UserID = " + UserID + @"
                            )
                            UNION ALL
                            (
                                SELECT DISTINCT c.Name, (c.ID + 0.2) as ID, (c.PermissionGroupID + 0.3) as ParentID, 
		                            '' AS CreatedByName, null as CreatedDate, c.ID AS MainID, 'Permission' AS Type
                                FROM UserAndPermissionDetail a, PermissionDetail b, Permission c, PermissionGroup d, PermissionGroupType e, Users f, Employees g
                                WHERE a.PermissionDetailID = b.ID
                                AND b.PermissionID = c.ID
                                AND c.PermissionGroupID = d.ID
                                AND d.PermissionGroupTypeID = e.ID
                                AND a.CreatedBy = f.ID
                                AND f.EmployeesID = g.ID
                                AND a.UserID = " + UserID + @"
                            )
                            UNION ALL
                            (
                                SELECT b.Name, (b.ID + 0.1) as ID, (b.PermissionID + 0.2) as ParentID, 
                                        g.FullName AS CreatedByName, 
                                        a.CreatedDate, b.ID AS MainID, 'PermissionDetail' AS Type
                                FROM UserAndPermissionDetail a, PermissionDetail b, Permission c, PermissionGroup d, PermissionGroupType e, Users f, Employees g
                                WHERE a.PermissionDetailID = b.ID
                                AND b.PermissionID = c.ID
                                AND c.PermissionGroupID = d.ID
                                AND d.PermissionGroupTypeID = e.ID
                                AND a.CreatedBy = f.ID
                                AND f.EmployeesID = g.ID
                                AND a.UserID = " + UserID + @"
                            )";
            return query;
        }

        public static string Users_GetToEdit(string UserName, string UserID)
        {
            return @"select *
                    from Users a
                    where a.UserName = '" + UserName + @"'
                    and a.ID <> " + UserID;
        }

        public static string Users_GetAll()
        {
            string query = @"SELECT a.ID, b.FullName AS Name
                            FROM Users a, Employees b
                            WHERE a.EmployeesID = b.ID";
            return query;
        }

        public static string Users_GetAllByStatus(int StatusID)
        {
            string query = @"SELECT a.ID, b.FullName AS Name
                            FROM Users a, Employees b
                            WHERE a.EmployeesID = b.ID
                            AND a.StatusID = " + StatusID + @"
                            AND b.StatusID = " + StatusID;
            return query;
        }

        public static string Users_ResetPassword(DataObject.dtoUsers User)
        {
            string query = "update Users " +
                           "set Password = N'" + User.Password + "', " +
                           "Password_ResetBy = " + User.Password_ResetBy + ", " +
                           "Password_ResetDate = '" + User.Password_ResetDate.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                           "where ID = " + User.ID;
            return query;
        }

        #endregion

        #region Employees

        public static string Employees_CheckToAdd(string FullName, string Gender, string BirthDay)
        {
            return @"select a.*
                    from Employees a
                    where a.FullName = N'" + FullName + @"'
                    and a.GenderID = " + Gender + @"
                    and a.BirthDay = '" + BirthDay + @"'";
        }

        public static string Employees_GetAll()
        {
            string query = @"SELECT a.ID, a.Code, a.FullName, a.BirthDay, a.IdentityCode, a.CellPhone, 
                                   a.Email, a.StartWorkingDate, a.EndWorkingDate,
	                               b.Name GenderName, a.Address,h.Name AS PositionName, i.Name AS StatusName,
                                   k.FullName AS CreatedByName, a.CreatedDate,
                                   m.FullName AS LastUpdatedByName, a.LastUpdatedDate,
                                   n.ID AS User_ID, n.UserName AS User_UserName, n.Password AS User_Password, 
                                   p.FullName AS User_CreatedByName, n.CreatedDate AS User_CreatedDate,
                                   s.FullName AS User_StoppedByName, n.StoppedDate AS User_StoppedDate,
                                   u.FullName AS User_LastUpdatedByName, n.LastUpdatedDate AS User_LastUpdatedDate,
                                   w.FullName AS User_Password_ResetByName, n.Password_ResetDate AS User_Password_ResetDate,
                                   y.Name AS User_StatusName, a.StatusID
                            FROM Employees a
                            LEFT JOIN Position h ON a.PositionID = h.ID
                            LEFT JOIN Users j ON a.CreatedBy = j.ID
                            LEFT JOIN Employees k ON j.EmployeesID = k.ID
                            LEFT JOIN Users l ON a.LastUpdatedBy = l.ID
                            LEFT JOIN Employees m ON l.EmployeesID = m.ID
                            LEFT JOIN Users n ON a.ID = n.EmployeesID
                            LEFT JOIN Users o ON n.CreatedBy = o.ID
                            LEFT JOIN Employees p ON o.EmployeesID = p.ID
                            LEFT JOIN Users q ON n.StoppedBy = q.ID
                            LEFT JOIN Employees s ON q.EmployeesID = s.ID
                            LEFT JOIN Users t ON n.LastUpdatedBy = t.ID
                            LEFT JOIN Employees u ON t.EmployeesID = u.ID
                            LEFT JOIN Users v ON n.Password_ResetBy = v.ID
                            LEFT JOIN Employees w ON v.EmployeesID = w.ID
                            LEFT JOIN Status y ON n.StatusID = y.ID
                            , Gender b, Status i
                            WHERE a.GenderID = b.ID
                            AND a.StatusID = i.ID";
            return query;
        }

        public static string Employees_GetByStatus(string StatusID)
        {
            string query = @"SELECT a.ID, a.Code, a.FullName, a.BirthDay, a.IdentityCode, a.CellPhone, 
                                   a.Email, a.StartWorkingDate, a.EndWorkingDate,
	                               b.Name GenderName, a.Address,h.Name AS PositionName, i.Name AS StatusName,
                                   k.FullName AS CreatedByName, a.CreatedDate,
                                   m.FullName AS LastUpdatedByName, a.LastUpdatedDate,
                                   n.ID AS User_ID, n.UserName AS User_UserName, n.Password AS User_Password, 
                                   p.FullName AS User_CreatedByName, n.CreatedDate AS User_CreatedDate,
                                   s.FullName AS User_StoppedByName, n.StoppedDate AS User_StoppedDate,
                                   u.FullName AS User_LastUpdatedByName, n.LastUpdatedDate AS User_LastUpdatedDate,
                                   w.FullName AS User_Password_ResetByName, n.Password_ResetDate AS User_Password_ResetDate,
                                   y.Name AS User_StatusName, a.StatusID
                            FROM Employees a
                            LEFT JOIN Position h ON a.PositionID = h.ID
                            LEFT JOIN Users j ON a.CreatedBy = j.ID
                            LEFT JOIN Employees k ON j.EmployeesID = k.ID
                            LEFT JOIN Users l ON a.LastUpdatedBy = l.ID
                            LEFT JOIN Employees m ON l.EmployeesID = m.ID
                            LEFT JOIN Users n ON a.ID = n.EmployeesID
                            LEFT JOIN Users o ON n.CreatedBy = o.ID
                            LEFT JOIN Employees p ON o.EmployeesID = p.ID
                            LEFT JOIN Users q ON n.StoppedBy = q.ID
                            LEFT JOIN Employees s ON q.EmployeesID = s.ID
                            LEFT JOIN Users t ON n.LastUpdatedBy = t.ID
                            LEFT JOIN Employees u ON t.EmployeesID = u.ID
                            LEFT JOIN Users v ON n.Password_ResetBy = v.ID
                            LEFT JOIN Employees w ON v.EmployeesID = w.ID
                            LEFT JOIN Status y ON n.StatusID = y.ID
                            , Gender b, Status i
                            WHERE a.GenderID = b.ID
                            AND a.StatusID = i.ID
                            AND a.StatusID = " + StatusID;
            return query;
        }

        #endregion

        #region Role

        public static string Role_GetAll()
        {
            return @"select a.*, b.Name AS StatusName, d.FullName AS CreatedByName, f.FullName AS LastUpdatedByName
                    from Role a
                    left join Users e on a.LastUpdatedBy = e.ID
                    left join Employees f on e.EmployeesID = f.ID, Status b, Users c, Employees d
                    where a.StatusID = b.ID
                    and a.CreatedBy = c.ID
                    and c.EmployeesID = d.ID";
        }

		public static string Role_GetByID(string RoleID)
		{
			return @"
                     (
	                    select b.ID + 0.4 AS ID, b.PermissionID + 0.3 AS ParentID, b.Name COLLATE utf8_general_ci as Name, 'PermissionDetail' AS Type, 
			                    a.CreatedDate, f.FullName AS CreatedByName, b.ID AS MainID
	                    from RoleDetail a, PermissionDetail b, Permission c, PermissionGroup d, Users e, Employees f
	                    where a.PermissionDetailID = b.ID
	                    and b.PermissionID = c.ID
	                    and c.PermissionGroupID = d.ID
	                    and a.CreatedBy = e.ID
	                    and e.EmployeesID = f.ID
	                    and a.RoleID = " + RoleID + @"
                    )
                    UNION ALL
                    (
	                    select distinct c.ID + 0.3 AS ID, c.PermissionGroupID + 0.2 AS ParentID, c.Name, 'Permission' AS Type, 
			                    NULL AS CreatedDate, '' AS CreatedByName, c.ID AS MainID
	                    from RoleDetail a, PermissionDetail b, Permission c, PermissionGroup d
	                    where a.PermissionDetailID = b.ID
	                    and b.PermissionID = c.ID
	                    and c.PermissionGroupID = d.ID
	                    and a.RoleID = " + RoleID + @"
                    )
                    UNION ALL
                    (
	                    select distinct d.ID + 0.2 AS ID, d.PermissionGroupTypeID + 0.1 AS ParentID, d.Name, 'PermissionGroup' AS Type, 
			                    NULL AS CreatedDate, '' AS CreatedByName, d.ID AS MainID
	                    from RoleDetail a, PermissionDetail b, Permission c, PermissionGroup d
	                    where a.PermissionDetailID = b.ID
	                    and b.PermissionID = c.ID
	                    and c.PermissionGroupID = d.ID
	                    and a.RoleID = " + RoleID + @"
                    )
                     UNION ALL
                    (
	                    select distinct e.ID + 0.1 AS ID, 0 AS ParentID, e.Name, 'PermissionGroupType' AS Type, 
			                    NULL AS CreatedDate, '' AS CreatedByName, e.ID AS MainID
	                    from RoleDetail a, PermissionDetail b, Permission c, PermissionGroup d, PermissionGroupType e
	                    where a.PermissionDetailID = b.ID
	                    and b.PermissionID = c.ID
	                    and c.PermissionGroupID = d.ID
                        and d.PermissionGroupTypeID = e.ID
	                    and a.RoleID = " + RoleID + @"
                    )
                    ";
		}

		public static string Role_GetAllPermissionToEdit(string RoleID)
		{
			return @"
                        (
	                    select b.ID + 0.4 AS ID, b.PermissionID + 0.3 AS ParentID, b.Name COLLATE utf8_general_ci as Name, 'PermissionDetail' AS Type, 
			                    a.CreatedDate, f.FullName AS CreatedByName, b.ID AS MainID
	                    from PermissionDetail b
	                    left join RoleDetail a on a.PermissionDetailID = b.ID and a.RoleID = " + RoleID + @"
	                    left join Users e on e.ID = a.CreatedBy
	                    left join Employees f on f.ID = e.EmployeesID, Permission c, PermissionGroup d
	                    where b.PermissionID = c.ID
	                    and c.PermissionGroupID = d.ID
                    )
                    UNION ALL
                    (
	                    select distinct c.ID + 0.3 AS ID, c.PermissionGroupID + 0.2 AS ParentID, c.Name, 'Permission' AS Type, 
			                    NULL AS CreatedDate, '' AS CreatedByName, c.ID AS MainID
	                    from PermissionDetail b, Permission c, PermissionGroup d
	                    where b.PermissionID = c.ID
	                    and c.PermissionGroupID = d.ID
                    )
                    UNION ALL
                    (
	                    select distinct d.ID + 0.2 AS ID, d.PermissionGroupTypeID + 0.1 AS ParentID, d.Name, 'PermissionGroup' AS Type, 
			                    NULL AS CreatedDate, '' AS CreatedByName, d.ID AS MainID
	                    from PermissionDetail b, Permission c, PermissionGroup d
	                    where b.PermissionID = c.ID
	                    and c.PermissionGroupID = d.ID
                    )
                    UNION ALL
                    (
	                    select distinct e.ID + 0.1 AS ID, 0 AS ParentID, e.Name, 'PermissionGroupType' AS Type, 
			                    NULL AS CreatedDate, '' AS CreatedByName, e.ID AS MainID
	                    from PermissionDetail b, Permission c, PermissionGroup d, PermissionGroupType e
	                    where b.PermissionID = c.ID
	                    and c.PermissionGroupID = d.ID
                        and d.PermissionGroupTypeID = e.ID
                    )
                    ";
		}

        #endregion

        #region UserAdministrator

        public static string UserAdministrator_GetPermission(List<string> lstPermission, string InOrNotIn)
        {
            string lst = string.Join(",", lstPermission.ToArray());
            if (lst == "")
                lst = "0";

            string query = @"(
                                SELECT DISTINCT d.Name COLLATE utf8_general_ci AS Name, (d.ID + 0.4) AS ID, 0 AS ParentID, 'PermissionGroupType' AS Type, d.ID AS MainID
                                FROM PermissionDetail a, Permission b, PermissionGroup c, PermissionGroupType d
                                WHERE a.PermissionID = b.ID
                                AND b.PermissionGroupID = c.ID
                                AND c.PermissionGroupTypeID = d.ID
                                AND a.ID " + InOrNotIn + @" (" + lst + @")
                            )
                            UNION ALL
                            (
                                SELECT DISTINCT c.Name, (c.ID + 0.3) AS ID, (c.PermissionGroupTypeID + 0.4) AS ParentID, 'PermissionGroup' AS Type, c.ID AS MainID
                                FROM PermissionDetail a, Permission b, PermissionGroup c, PermissionGroupType d
                                WHERE a.PermissionID = b.ID
                                AND b.PermissionGroupID = c.ID
                                AND c.PermissionGroupTypeID = d.ID
                                AND a.ID " + InOrNotIn + @" (" + lst + @")
                            )
                            UNION ALL
                            (
                                SELECT DISTINCT b.Name, (b.ID + 0.2) AS ID, (b.PermissionGroupID + 0.3) AS ParentID, 'Permission' AS Type, b.ID AS MainID
                                FROM PermissionDetail a, Permission b, PermissionGroup c, PermissionGroupType d
                                WHERE a.PermissionID = b.ID
                                AND b.PermissionGroupID = c.ID
                                AND c.PermissionGroupTypeID = d.ID
                                AND a.ID " + InOrNotIn + @" (" + lst + @")
                            )
                            UNION ALL
                            (
                                SELECT a.Name, (a.ID + 0.1) AS ID, (a.PermissionID + 0.2) AS ParentID, 'PermissionDetail' AS Type, a.ID AS MainID
                                FROM PermissionDetail a, Permission b, PermissionGroup c, PermissionGroupType d
                                WHERE a.PermissionID = b.ID
                                AND b.PermissionGroupID = c.ID
                                AND c.PermissionGroupTypeID = d.ID
                                AND a.ID " + InOrNotIn + @" (" + lst + @")
                            )";
            return query;
        }

        public static string UserAdministrator_GetRole(List<string> lstRole, string InOrNotIn)
        {
            string lst = string.Join(",", lstRole.ToArray());
            if (lst == "")
                lst = "0";

            string query = @"SELECT * 
                             FROM Role a
                             WHERE a.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                             AND a.ID " + InOrNotIn + @" (" + lst + @")";
            return query;
        }

        #endregion

        #region Menu

        public static string Menu_GetListOfSizes(string MenuID)
        {
            return @"SELECT * 
                    FROM Menu_Size AS a, Size As b
                    WHERE a.SizeID = b.ID
                    AND a.MenuID = " + MenuID + @"
                    ORDER BY b.RankIndex ASC";

        }

        public static string Menu_GetByStatus_FullSize(string StatusID)
        {
            return @"SELECT a.ID, a.Code, a.Name, a.Formula, a.AvatarPicture, 
	                       a.Note, a.MenuGroupID, a.StatusID, a.UnitID, a.TasteQTy,
                    GROUP_CONCAT(c.Name ORDER BY c.Name DESC) AS 'SizeName', a.PrintSticker
                    FROM Menu AS a 
                    LEFT JOIN Menu_Size AS b ON a.ID = b.MenuID
                    LEFT JOIN Size AS c ON c.ID = b.SizeID
                    WHERE a.StatusID = " + StatusID + @"
                    GROUP BY a.ID, a.Code, a.Name, a.Formula, a.AvatarPicture, 
	                       a.Note, a.MenuGroupID, a.StatusID, a.UnitID, a.TasteQTy, a.PrintSticker
                    ORDER BY a.Name ASC";

        }

        public static string Menu_GetAll_IsActive()
        {
            return @"SELECT a.*
                    FROM Menu AS a, MenuGroup AS b
                    WHERE a.MenuGroupID = b.ID
                    AND a.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                    AND b.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                    ORDER BY b.Name, a.Name";

        }

        public static string Menu_GetAll_FullSize_IsActive()
        {
            return @"SELECT a.*, c.SizeID, concat(a.ID,',',c.SizeID) as MenuID_SizeID
                    FROM Menu AS a, MenuGroup AS b, Menu_Size c
                    WHERE a.MenuGroupID = b.ID
                    AND a.ID = c.MenuID
                    AND a.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                    AND b.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                    ORDER BY b.Name, a.Name, c.SizeID";

        }

        public static string Menu_PriceList_GetIsActive()
        {
            return @"SELECT 0 AS PriceListID, a.ID AS MenuID, c.CostPrice, c.SalePrice, c.SalePrice AS Price, MenuGroupID, 
                        UnitID, c.SalePrice - c.CostPrice AS Deviated, c.SizeID
                     FROM Menu AS a, MenuGroup AS b, Menu_Size AS c
                     WHERE a.MenuGroupID = b.ID
                     AND a.ID = c.MenuID
                     AND a.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                     AND b.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động;
        }

        public static string Menu_GetListGroups()
        {
            return @"SELECT DISTINCT b.*
                    FROM Menu AS a, MenuGroup AS b
                    WHERE a.MenuGroupID = b.ID
                    AND a.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                    AND b.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                    ORDER BY b.Name";
        }

        public static string Menu_GetByGroup(string GroupMenuID)
        {
            return @"SELECT a.*
                    FROM Menu AS a
                    WHERE a.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                    AND a.MenuGroupID = "+ GroupMenuID + @"
                    ORDER BY a.Name";
        }

        #endregion

        #region PriceList

        public static string PriceList_GetByID_Expired(string PriceListID)
        {
            return @"SELECT a.PriceListID, a.MenuID, a.Price, c.CostPrice, c.SalePrice, MenuGroupID, UnitID, IFNULL(a.Price,0) - IFNULL(c.CostPrice,0) AS Deviated, c.SizeID
                     FROM PriceListDetail AS a, Menu AS b, Menu_Size AS c
                     WHERE a.MenuID = c.MenuID
                     AND a.SizeID = c.SizeID
                     AND b.ID = c.MenuID
                     AND a.PriceListID = " + PriceListID;
        }

        public static string PriceList_GetByID(string PriceListID)
        {
            return @"SELECT INFO1.MenuID, INFO1.CostPrice, INFO1.SalePrice, INFO1.MenuGroupID, INFO1.UnitID, 
                            CASE
			                    WHEN INFO2.PriceListID IS NULL THEN " + PriceListID + @"
			                    ELSE INFO2.PriceListID
		                    END PriceListID, INFO2.Price, IFNULL(INFO2.Price,0) - IFNULL(INFO1.CostPrice,0) AS Deviated, INFO1.SizeID
                     FROM
                     (
	                    SELECT a.ID AS MenuID, c.CostPrice, c.SalePrice, a.MenuGroupID, a.UnitID, c.SizeID
	                    FROM Menu AS a, MenuGroup AS b, Menu_Size AS c
	                    WHERE a.MenuGroupID = b.ID
                        AND a.ID = c.MenuID
	                    AND a.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
	                    AND b.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                     ) INFO1 LEFT JOIN
                     (                
	                    SELECT PriceListID, Price, MenuID, SizeID
	                    FROM PriceListDetail
	                    WHERE PriceListID = " + PriceListID + @"
                     ) INFO2 
                     ON INFO1.MenuID = INFO2.MenuID 
                        AND INFO1.SizeID = INFO2.SizeID";
        }

        public static string PriceList_IsUsing_GetMenu(string MenuID, string SizeID)
        {
            string query = @"SELECT c.*, b.Price, b.PriceListID, f.Name As SizeName
                     FROM PriceList AS a, PriceListDetail AS b, Menu_Size AS e, Menu AS c, MenuGroup AS d, Size AS f
                     WHERE a.ID = b.PriceListID
                     AND b.MenuID = e.MenuID
                     AND b.SizeID = e.SizeID
                     AND e.MenuID = c.ID
                     AND c.MenuGroupID = d.ID
                     AND b.SizeID = f.ID
                     AND c.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                     AND d.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                     AND a.StatusOfPriceListID = " + (int)Utilities.CategoriesEnum.StatusOfPriceList.Đang_hiện_hành;

            if (MenuID != null && MenuID != "")
                query = query + " AND b.MenuID = " + MenuID;

            if (SizeID != null && SizeID != "")
                query = query + " AND b.SizeID = " + SizeID;

            return query;
        }

        #endregion

        #region Order

        public static string Order_GetDinnerTable(bool GetIsEmpty)
        {
            string query = @"SELECT * 
                     FROM DinnerTable
                     WHERE StatusOfDinnerTableID = " + (int)Utilities.CategoriesEnum.StatusOfDinnerTable.Đang_sử_dụng;

            if (GetIsEmpty)
                query = query + " AND ID NOT IN (SELECT DinnerTableID FROM Orders WHERE StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thanh_toán + @")";
            else
                query = query + " AND ID IN (SELECT DinnerTableID FROM Orders WHERE StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thanh_toán + @")";
            
            query = query + " ORDER BY Name ASC";

            return query;
        }

        public static string Order_GetNoPayment()
        {
            return @"SELECT  a.ID OrderID, a.DinnerTableID, b.Name DinnerTableName, b.UsingPicture, c.FullName AS OrderByName, a.OrderDate, a.Note
                    FROM Orders AS a, DinnerTable AS b, Employees AS c
                    WHERE a.DinnerTableID = b.ID
                    AND a.OrderBy = c.ID
                    AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thanh_toán + @"
                    ORDER BY b.Name ASC";
        }

        public static string Order_GetNoCollected()
        {
            return @"SELECT  a.ID OrderID, a.DinnerTableID, b.Name DinnerTableName, b.UsingPicture, d.FullName AS PaymentedByName, a.PaymentedDate, a.Note
                    FROM Orders AS a, DinnerTable AS b, Users AS c, Employees AS d
                    WHERE a.DinnerTableID = b.ID
                    AND a.PaymentedBy = c.ID
                    AND c.EmployeesID = d.ID
                    AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thu_tiền + @"
                    ORDER BY b.Name, a.PaymentedDate ASC";
        }

        public static string Order_GetPaymentedByDate(DateTime DateFrom, DateTime DateTo)
        {
            return @"SELECT  a.ID OrderID, a.DinnerTableID, b.Name DinnerTableName, b.UsingPicture, d.FullName AS PaymentedByName, a.PaymentedDate, a.Note
                    FROM Orders AS a, DinnerTable AS b, Users AS c, Employees AS d
                    WHERE a.DinnerTableID = b.ID
                    AND a.PaymentedBy = c.ID
                    AND c.EmployeesID = d.ID
                    AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền + @"
                    AND a.PaymentedDate BETWEEN '" + DateFrom.ToString("yyyy-MM-dd HH:mm:ss") + @"' AND '" + DateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                    ORDER BY b.Name, a.PaymentedDate ASC";
        }

        public static string Order_GetCancelledByDate(DateTime DateFrom, DateTime DateTo)
        {
            return @"SELECT  a.ID OrderID, a.DinnerTableID, b.Name DinnerTableName, b.UsingPicture, d.FullName AS CancelledByName, a.CancelledDate, a.Note
                    FROM Orders AS a, DinnerTable AS b, Users AS c, Employees AS d
                    WHERE a.DinnerTableID = b.ID
                    AND a.CancelledBy = c.ID
                    AND c.EmployeesID = d.ID
                    AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Hủy + @"
                    AND a.CancelledDate BETWEEN '" + DateFrom.ToString("yyyy-MM-dd HH:mm:ss") + @"' AND '" + DateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                    ORDER BY b.Name, a.CancelledDate ASC";
        }

        public static string OrderDetail_GetByOrderID(string OrderID, bool IsCancelled)
        {
            string query = @"SELECT a.*, b.Name AS MenuName, c.Name AS MenuGroupName, d.Name AS UnitName, a.Quantity * a.Price AS Total,
                                    e.Name AS KindOfHotpot1Name, f.Name AS KindOfHotpot2Name, g.Name AS SizeName, b.PrintSticker
                            FROM OrdersDetail AS a
                            LEFT JOIN KindOfHotpot AS e ON a.KindOfHotpot1ID = e.ID
                            LEFT JOIN KindOfHotpot AS f ON a.KindOfHotpot2ID = f.ID 
                            LEFT JOIN Size AS g ON a.SizeID = g.ID, Menu AS b, MenuGroup AS c, Unit AS d
                            WHERE a.MenuID = b.ID
                            AND b.MenuGroupID = c.ID
                            AND b.UnitID = d.ID ";

            if (IsCancelled)
                query = query + " AND a.CancelledBy IS NOT NULL";
            else
                query = query + " AND a.CancelledBy IS NULL";

            query = query + " AND a.OrderID = " + OrderID;// + @" ORDER BY MenuGroupName, MenuName ASC";

            return query;
        }

        public static string Order_GetByID(string OrderID)
        {
            string query = @"SELECT a.*, b.Name AS DinnerTableName
                            FROM Orders AS a, DinnerTable AS b
                            WHERE a.DinnerTableID = b.ID
                            AND a.ID = " + OrderID;

            return query;
        }

        public static string Order_GetMaterials(string OrderID)
        {
            string query = @"SELECT c.MaterialsID, d.Name MaterialsName, (b.QuantityMenu * c.Quantity) AS Quantity
                            FROM
                            (
                                SELECT a.MenuID, a.SizeID, SUM(a.Quantity) AS QuantityMenu
                                FROM OrdersDetail AS a
                                WHERE a.CancelledBy IS NULL
                                AND a.OrderID = " + OrderID + @"
                                GROUP BY a.MenuID, a.SizeID
                            ) AS b, MenuAndMaterials AS c, Materials AS d
                            WHERE b.MenuID = c.MenuID
                            AND b.SizeID = c.SizeID
                            AND c.MaterialsID = d.ID";

            return query;
        }

        public static string Order_GetWarehouse(string MaterialsID)
        {
            string query = @"SELECT ID, QuantityCurrent
                            FROM Warehouse 
                            WHERE StatusID = " + (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Đã_nhập_kho + @"
                            AND QuantityCurrent > 0
                            AND MaterialsID = " + MaterialsID + @"
                            ORDER BY QuantityCurrent ASC";

            return query;
        }

        public static string Order_GetWarehouse_All()
        {
            string query = @"SELECT ID, MaterialsID, QuantityCurrent
                            FROM Warehouse 
                            WHERE StatusID = " + (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Đã_nhập_kho + @"
                            AND QuantityCurrent > 0
                            ORDER BY MaterialsID, QuantityCurrent ASC";

            return query;
        }

        #endregion

        #region Report

        public static string Report_Revenue_Employee(string ActionBy, DateTime ActionDateFrom, DateTime ActionDateTo, string PaymentedType)
        {
            string query = @"SELECT a.ID, b.Name AS DinnerTableName, d.FullName AS OrderByName, a.OrderDate, f.FullName AS PaymentedByName, a.PaymentedDate, PaymentedTotal, BillNo, a.Note, 
                                    PromotionPercent, PromotionAmount, TotalAmount,
                                    CASE	
                                    	WHEN a.PaymentedType = 'CASH' THEN 'Tiền mặt'
                                        WHEN a.PaymentedType = 'BANK' THEN 'Chuyển khoản'
                                        WHEN a.PaymentedType = 'GRAB' THEN 'Grab'
                                        WHEN a.PaymentedType = 'SHOPEE' THEN 'ShopeeFood'
                                        ELSE ''
                                    END PaymentedType
                            FROM Orders AS a
                            LEFT JOIN Users AS c ON a.OrderBy = c.ID
                            LEFT JOIN Employees d ON c.EmployeesID = d.ID, DinnerTable AS b, Users AS e, Employees AS f
                            WHERE a.DinnerTableID = b.ID
                            AND a.PaymentedBy = e.ID
                            AND e.EmployeesID = f.ID
                            AND a.ActionDate BETWEEN '" + ActionDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + ActionDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                            AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền;

            if (ActionBy != null && ActionBy != "")
                query = query + @" AND a.ActionBy = " + ActionBy;

            if (PaymentedType != null && PaymentedType != "")
                query = query + @" AND a.PaymentedType IN (" + PaymentedType + ")";

            return query;
        }

        public static string Report_Revenue_Employee_Detail(string ActionBy, DateTime ActionDateFrom, DateTime ActionDateTo, string PaymentedType)
        {
            string query = @"SELECT g.*, g.Quantity * g.Price Total, h.UnitID
                            FROM Orders AS a
                            LEFT JOIN Users AS c ON a.OrderBy = c.ID
                            LEFT JOIN Employees d ON c.EmployeesID = d.ID, DinnerTable AS b, Users AS e, Employees AS f, OrdersDetail g, Menu h
                            WHERE a.DinnerTableID = b.ID
                            AND a.PaymentedBy = e.ID
                            AND e.EmployeesID = f.ID
                            AND a.ID = g.OrderID
                            AND g.MenuID = h.ID
                            AND g.CancelledBy IS NULL
                            AND a.ActionDate BETWEEN '" + ActionDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + ActionDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                            AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền;

            if (ActionBy != null && ActionBy != "")
                query = query + @" AND a.ActionBy = " + ActionBy;

            query = query + @" AND a.PaymentedType IN (" + PaymentedType + ")";

            return query;
        }

        public static string Report_Revenue_Employee_ActualExport(string ActionBy, DateTime ActionDateFrom, DateTime ActionDateTo, string PaymentedType)
        {
            string vQuery = @"SELECT a.OrderID, b.MaterialsID, SUM(a.QuantitySubtract) AS QuantitySubtract, d.UnitID
                              FROM WarehouseRollback AS a, Warehouse AS b, Orders AS c, Materials d
                              WHERE a.WarehouseID = b.ID
                              AND a.OrderID = c.ID
                              AND b.MaterialsID = d.ID
                              AND c.ActionDate BETWEEN '" + ActionDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + ActionDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                              AND c.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền;

            if (ActionBy != null && ActionBy != "")
                vQuery = vQuery + @" AND c.ActionBy = " + ActionBy;

            vQuery = vQuery + @" AND c.PaymentedType IN (" + PaymentedType + ")";
            vQuery = vQuery + @" GROUP BY a.OrderID, b.MaterialsID, d.UnitID";

            return vQuery;
        }

        public static string Report_Revenue_Employee_GetListEmployees(DateTime PaymentedDateFrom, DateTime PaymentedDateTo)
        {
            string query = @"SELECT DISTINCT a.ActionBy, c.FullName AS ActionByName
                            FROM Orders AS a, Users AS b, Employees AS c
                            WHERE a.ActionBy = b.ID
                            AND b.EmployeesID = c.ID
                            AND a.ActionDate BETWEEN '" + PaymentedDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + PaymentedDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                            AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền;

            return query;
        }

        public static string Report_Revenue_GetListPaymentedType(DateTime PaymentedDateFrom, DateTime PaymentedDateTo)
        {
            string query = @"SELECT DISTINCT a.PaymentedType AS ID, 
                                    CASE	
                                    	WHEN a.PaymentedType = 'CASH' THEN 'Tiền mặt'
                                        WHEN a.PaymentedType = 'BANK' THEN 'Chuyển khoản'
                                        WHEN a.PaymentedType = 'GRAB' THEN 'Grab'
                                        WHEN a.PaymentedType = 'SHOPEE' THEN 'ShopeeFood'
                                        ELSE ''
                                    END Name
                            FROM Orders AS a
                            WHERE a.ActionDate BETWEEN '" + PaymentedDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + PaymentedDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                            AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền;

            return query;
        }

        public static string Report_Inventory()
        {
            return @"SELECT a.MaterialsID, b.Name, b.Code, d.Name UnitID, e.Name UnitID_Max, 
                            concat(b.StyleQuantity,' ',d.Name,'/',e.Name) StyleQuantity, SUM(a.QuantityCurrent) QuantityCurrent, 
                            SUM(a.QuantityCurrent)/b.StyleQuantity QuantityCurrent_Box, 
                            c.Name AS MaterialsGroupName
                    FROM Warehouse AS a, Materials AS b, MaterialsGroup AS c, Unit AS d, Unit AS e
                    WHERE a.MaterialsID = b.ID
                    AND b.MaterialsGroupID = c.ID
                    AND b.UnitID = d.ID
                    AND b.UnitID_Max = e.ID
                    AND a.StatusID = " + (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Đã_nhập_kho + @"
                    GROUP BY a.MaterialsID
                    HAVING SUM(a.QuantityCurrent)>0";
        }

        public static string Report_Inventory_GetPriceNearest(string MaterialsID)
        {
            return @"SELECT d.PriceImport
                    FROM ImportFromSuppliers AS c, Warehouse AS d
                    WHERE c.ID = d.ImportFromSuppliersID
                    AND c.StatusID = " + (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Đã_nhập_kho + @"
                    AND d.StatusID = " + (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Đã_nhập_kho + @"
                    AND d.MaterialsID = " + MaterialsID + @"
                    AND c.ImportedDate IN (
                                            SELECT MAX(b.ImportedDate)
                                            FROM Warehouse AS a, ImportFromSuppliers AS b
                                            WHERE a.ImportFromSuppliersID = b.ID
                                            AND a.StatusID = " + (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Đã_nhập_kho + @"
                                            AND b.StatusID = " + (int)Utilities.CategoriesEnum.ImportFromSuppliersStatus.Đã_nhập_kho + @"
                                            AND a.MaterialsID = " + MaterialsID + @"
    				                     )";
        }

        public static string Report_BestSeller(DateTime DateFrom, DateTime DateTo, bool ViewByDate)
        {
            if (ViewByDate)
            {
                return @"select c.Code, c.Name, sum(b.Quantity) TotalQuantity, d.Name MenuGroup, sum(b.Price * b.Quantity) TotalAmount, 
                         date(a.ActionDate) ActionDate, b.SizeID
                    from Orders as a, OrdersDetail as b, Menu as c, MenuGroup d
                    where a.ID = b.OrderID
                    and b.MenuID = c.ID
                    and c.MenuGroupID = d.ID
                    and b.CancelledBy is null
                    and a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền + @"
                    and a.ActionDate between '" + DateFrom.ToString("yyyy-MM-dd HH:mm:ss") + @"' and '" + DateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                    group by c.Code, c.Name, MenuGroup, date(a.ActionDate), b.SizeID
                    order by TotalQuantity desc";
            }
            else
            {
                return @"select c.Code, c.Name, sum(b.Quantity) TotalQuantity, d.Name MenuGroup, sum(b.Price * b.Quantity) TotalAmount, b.SizeID
                    from Orders as a, OrdersDetail as b, Menu as c, MenuGroup d
                    where a.ID = b.OrderID
                    and b.MenuID = c.ID
                    and c.MenuGroupID = d.ID
                    and b.CancelledBy is null
                    and a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền + @"
                    and a.ActionDate between '" + DateFrom.ToString("yyyy-MM-dd HH:mm:ss") + @"' and '" + DateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                    group by c.Code, c.Name, MenuGroup, b.SizeID
                    order by TotalQuantity desc";
            }
        }

        public static string Report_Revenue_SummaryOfRevenueByEmployee(string ActionBy, DateTime ActionDateFrom, DateTime ActionDateTo)
        {
            string vActionBy = "";
            if (ActionBy != null && ActionBy != "")
                vActionBy = @" AND a.ActionBy = " + ActionBy;

            string vQuery = @"  SELECT PaymentedByID, PaymentedByName, SUM(Cash) Cash, SUM(Bank) Bank, SUM(Grab) Grab, SUM(Shopee) Shopee, 0 Total
                                FROM (
                                        (
                                            SELECT f.ID PaymentedByID, f.FullName AS PaymentedByName, PaymentedTotal Cash, 0 Bank, 0 Grab, 0 Shopee
                                            FROM Orders AS a
                                            LEFT JOIN Users AS c ON a.OrderBy = c.ID
                                            LEFT JOIN Employees d ON c.EmployeesID = d.ID, DinnerTable AS b, Users AS e, Employees AS f
                                            WHERE a.DinnerTableID = b.ID
                                            AND a.PaymentedBy = e.ID
                                            AND e.EmployeesID = f.ID
                                            AND a.ActionDate BETWEEN '" + ActionDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + ActionDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                                            AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền + @" 
                                            " + vActionBy + @" 
                                            AND a.PaymentedType = 'CASH'
                                        )
                                        UNION ALL
                                        (
                                            SELECT f.ID PaymentedByID, f.FullName AS PaymentedByName, 0 Cash, PaymentedTotal Bank, 0 Grab, 0 Shopee
                                            FROM Orders AS a
                                            LEFT JOIN Users AS c ON a.OrderBy = c.ID
                                            LEFT JOIN Employees d ON c.EmployeesID = d.ID, DinnerTable AS b, Users AS e, Employees AS f
                                            WHERE a.DinnerTableID = b.ID
                                            AND a.PaymentedBy = e.ID
                                            AND e.EmployeesID = f.ID
                                            AND a.ActionDate BETWEEN '" + ActionDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + ActionDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                                            AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền + @"  
                                            " + vActionBy + @"
                                            AND a.PaymentedType = 'BANK'
                                        )
                                        UNION ALL
                                        (
                                            SELECT f.ID PaymentedByID, f.FullName AS PaymentedByName, 0 Cash, 0 Bank, PaymentedTotal Grab, 0 Shopee
                                            FROM Orders AS a
                                            LEFT JOIN Users AS c ON a.OrderBy = c.ID
                                            LEFT JOIN Employees d ON c.EmployeesID = d.ID, DinnerTable AS b, Users AS e, Employees AS f
                                            WHERE a.DinnerTableID = b.ID
                                            AND a.PaymentedBy = e.ID
                                            AND e.EmployeesID = f.ID
                                            AND a.ActionDate BETWEEN '" + ActionDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + ActionDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                                            AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền + @"  
                                            " + vActionBy + @" 
                                            AND a.PaymentedType = 'GRAB'
                                        )
                                        UNION ALL
                                        (
                                            SELECT f.ID PaymentedByID, f.FullName AS PaymentedByName, 0 Cash, 0 Bank, 0 Grab, PaymentedTotal Shopee
                                            FROM Orders AS a
                                            LEFT JOIN Users AS c ON a.OrderBy = c.ID
                                            LEFT JOIN Employees d ON c.EmployeesID = d.ID, DinnerTable AS b, Users AS e, Employees AS f
                                            WHERE a.DinnerTableID = b.ID
                                            AND a.PaymentedBy = e.ID
                                            AND e.EmployeesID = f.ID
                                            AND a.ActionDate BETWEEN '" + ActionDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + ActionDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                                            AND a.StatusOfOrderID = " + (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền + @" 
                                            " + vActionBy + @"
                                            AND a.PaymentedType = 'SHOPEE'
                                        )
                                  )INFO
                                  GROUP BY PaymentedByID, PaymentedByName";

            return vQuery;
        }

        #endregion

        #region CollectAndSpend

        public static string CollectAndSpend_GetName()
        {
            return @"SELECT DISTINCT Name AS Name FROM CollectAndSpend ORDER BY Name ASC";
        }

        #endregion

        #region PromotionOnTotalBill

        public static string PromotionOnTotalBill_GetAll()
        {
            return @"SELECT a.*, c.FullName CreatedByName, e.FullName UpdatedByName
                    FROM PromotionOnTotalBill AS a
                    LEFT JOIN Users AS d ON a.UpdatedBy = d.ID
                    LEFT JOIN Employees AS e ON d.EmployeesID = e.ID, Users AS b, Employees AS c
                    WHERE a.CreatedBy = b.ID
                    AND b.EmployeesID = c.ID
                    ORDER BY StartDate ASC";
        }

        #endregion

        #region MenuAndMaterials

        public static string MenuAndMaterials_GetAllIsActive()
        {
            return @"SELECT a.*, b.Name, b.Code, b.StatusID, b.UnitID, concat(a.MenuID,',',a.SizeID) as MenuID_SizeID
                    FROM MenuAndMaterials AS a, Materials AS b, Menu AS c, MenuGroup AS d
                    WHERE a.MaterialsID = b.ID
                    AND a.MenuID = c.ID                    
                    AND c.MenuGroupID = d.ID
                    AND c.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                    AND d.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                    AND concat(a.MenuID,',',a.SizeID) IN (
                                                            SELECT concat(a.ID,',',c.SizeID) as MenuID_SizeID
                                                            FROM Menu AS a, MenuGroup AS b, Menu_Size c
                                                            WHERE a.MenuGroupID = b.ID
                                                            AND a.ID = c.MenuID
                                                            AND a.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                                                            AND b.StatusID = " + (int)Utilities.CategoriesEnum.Status.Đang_hoạt_động + @"
                                                         )
                    ORDER BY b.Name ASC";
        }

        public static string MenuAndMaterials_GetByMenuIDAndSizeID(string MenuID, string SizeID)
        {
            return @"SELECT a.*, b.Name, b.ID AS MaterialsID
                    FROM MenuAndMaterials a, Materials b
                    WHERE a.MaterialsID = b.ID 
                    AND a.MenuID = " + MenuID + @"
                    AND a.SizeID = " + SizeID;
        }

        public static string MenuAndMaterials_GetMaterials(string MaterialsGroupID_Exclude)
        {
            return @"SELECT a.*, b.Name MaterialsGroupName, b.Name MaterialsGroupName_Sub, c.Name UnitName, d.Name UnitName_Max
                    FROM Materials AS a
                    LEFT JOIN Unit AS c ON a.UnitID = c.ID
                    LEFT JOIN Unit AS d ON a.UnitID_Max = d.ID
                    JOIN MaterialsGroup AS b ON a.MaterialsGroupID = b.ID
                    WHERE a.MaterialsGroupID <> " + MaterialsGroupID_Exclude + @"
                    AND a.StatusID = " + (int)Utilities.CategoriesEnum.MaterialsStatus.Đang_sử_dụng;
        }

        #endregion

        #region ImportFromSuppliers

        public static string ImportFromSuppliers_GetMaterials()
        {
            return @"SELECT a.*, b.Name UnitID_Name, c.Name UnitID_Max_Name
                    FROM Materials AS a, Unit AS b, Unit AS c
                    WHERE a.UnitID = b.ID
                    AND a.UnitID_Max = c.ID
                    AND a.StatusID = " + (int)Utilities.CategoriesEnum.MaterialsStatus.Đang_sử_dụng + @"
                    AND a.MaterialsGroupID <> " + (int)Utilities.CategoriesEnum.MaterialsGroup.Vật_tư_và_Thiết_bị + @"
                    AND StyleQuantity > 0
                    AND UnitID IS NOT NULL
                    ORDER BY a.Name";
        }

        public static string ImportFromSuppliers_GetPriceNearest(string MaterialsID, string ImportFromSuppliersID_Exclude)
        {
            return @"SELECT b.PriceImport
                    FROM ImportFromSuppliers AS a, Warehouse AS b
                    WHERE a.ID = b.ImportFromSuppliersID
                    AND a.ImportedDate IN (
                                                SELECT MAX(b.ImportedDate)
                                                FROM Warehouse AS a, ImportFromSuppliers AS b
                                                WHERE a.ImportFromSuppliersID = b.ID
                                                AND a.ImportFromSuppliersID <> " + ImportFromSuppliersID_Exclude + @"
                                                AND a.MaterialsID = " + MaterialsID + @"
    					                    )
                    AND b.MaterialsID = " + MaterialsID;
        }

        public static string ImportFromSuppliers_GetPriceNearest(string MaterialsID)
        {
            return @"SELECT b.PriceImport
                    FROM ImportFromSuppliers AS a, Warehouse AS b
                    WHERE a.ID = b.ImportFromSuppliersID
                    AND a.ImportedDate IN (
                                                SELECT MAX(b.ImportedDate)
                                                FROM Warehouse AS a, ImportFromSuppliers AS b
                                                WHERE a.ImportFromSuppliersID = b.ID
                                                AND a.MaterialsID = " + MaterialsID + @"
    					                    )
                    AND b.MaterialsID = " + MaterialsID;
        }

        public static string ImportFromSuppliers_GetWarehouse(DateTime ImportedDateFrom, DateTime ImportedDateTo)
        {
            return @"SELECT a.*, b.UnitID
                    FROM Warehouse AS a, Materials AS b
                    WHERE a.MaterialsID = b.ID
                    AND a.ImportFromSuppliersID IN (
                                                        SELECT ID 
                                                        FROM ImportFromSuppliers 
                                                        WHERE ImportedDate BETWEEN '" + ImportedDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + @"' AND '" + ImportedDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'
                                                   )";
        }

        #endregion

        #region Payroll

        public static string AttendanceData_GetListOfEmployees(DateTime AttendanceTimeFrom, DateTime AttendanceTimeTo, int StatusID)
        {
            return @"SELECT DISTINCT b.ID, b.FullName, b.SalaryByHour
                    FROM AttendanceData AS a, Employees AS b
                    WHERE a.EmployeeID = b.ID
                    AND a.StatusID = " + StatusID + @"
                    AND a.AttendanceTime BETWEEN '"+ AttendanceTimeFrom.ToString("yyyy-MM-dd HH:mm:ss") + @"' AND '" + AttendanceTimeTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'";
        }

        public static string Payroll_GetListOfEmployees(DateTime CreatedDateFrom, DateTime CreatedDateTo)
        {
            return @"SELECT DISTINCT b.ID, b.FullName
                    FROM Payroll AS a, Employees AS b
                    WHERE a.EmployeeID = b.ID
                    AND a.CreatedDate BETWEEN '" + CreatedDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + @"' AND '" + CreatedDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'";
        }

        public static string Payroll_GetListOfCreatedBy(DateTime CreatedDateFrom, DateTime CreatedDateTo)
        {
            return @"SELECT DISTINCT b.ID, c.FullName
                    FROM Payroll AS a, Users AS b, Employees AS c
                    WHERE a.CreatedBy = b.ID
                    AND b.EmployeesID = c.ID
                    AND a.CreatedDate BETWEEN '" + CreatedDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + @"' AND '" + CreatedDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'";
        }

        #endregion

        #region Overtime

        public static string Overtime_GetListOfEmployees(DateTime WorkingDateFrom, DateTime WorkingDateTo)
        {
            return @"SELECT DISTINCT b.ID, b.FullName
                    FROM Overtime AS a, Employees AS b
                    WHERE a.EmployeeID = b.ID
                    AND a.WorkingDate BETWEEN '" + WorkingDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + @"' AND '" + WorkingDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'";
        }

        public static string Overtime_GetListOfCreatedBy(DateTime WorkingDateFrom, DateTime WorkingDateTo)
        {
            return @"SELECT DISTINCT b.ID, c.FullName
                    FROM Overtime AS a, Users AS b, Employees AS c
                    WHERE a.CreatedBy = b.ID
                    AND b.EmployeesID = c.ID
                    AND a.CreatedDate BETWEEN '" + WorkingDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + @"' AND '" + WorkingDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'";
        }

        public static string Overtime_GetListOfApprovedBy(DateTime WorkingDateFrom, DateTime WorkingDateTo)
        {
            return @"SELECT DISTINCT b.ID, c.FullName
                    FROM Overtime AS a, Users AS b, Employees AS c
                    WHERE a.ApprovedBy = b.ID
                    AND b.EmployeesID = c.ID
                    AND a.CreatedDate BETWEEN '" + WorkingDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + @"' AND '" + WorkingDateTo.ToString("yyyy-MM-dd HH:mm:ss") + @"'";
        }

        #endregion
    }
}
