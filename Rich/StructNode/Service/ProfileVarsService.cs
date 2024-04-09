using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using static Tekla.Structures.Model.UI.GraphicPolyLine;

namespace StructNode
{

    internal class ProfileVarsService
    {
        Part myPart = null;
        public ProfileVarsService(Part part)
        {
            this.myPart = part;
        }

        public double GetProfileHeight()
        {
            double dHeight = 0;
            if (myPart != null)
            {
                myPart.GetReportProperty("PROFILE.HEIGHT", ref dHeight);
            }
            return dHeight;
        }
        public double GetProfileWidth()
        {
            double dWidth = 0;
            if (myPart != null)
            {
                myPart.GetReportProperty("PROFILE.WIDTH", ref dWidth);
            }
            return dWidth;
        }
        public double GetProfileWebThickness()
        {
            double dThickness = 0;
            if (myPart != null)
            {
                myPart.GetReportProperty("PROFILE.WEB_THICKNESS", ref dThickness);
            }
            return dThickness;
        }
    }
}
//class GJGSectionVarsService
//{
//    public:
//    GJGSectionVarsService(GJGSectionObj& oModel);
//    GJGSectionVarsService(GJGElementSection& oModel);
//    GJGSectionVarsService(std::shared_ptr<GJGSectionObjRepo> repo, int nId);
//    virtual ~GJGSectionVarsService() { };

//    /*!
//    * @brief      直接获取截面参数
//    * @author     zhangr-k
//    * @date       2022/03/18
//    * @return     std::unordered_map<std::string, double>
//    */

//    /*!
//    * @brief      截面水平方向最大宽度
//    * @author     zhangr-k
//    * @date       2022/03/21
//    * @param[in]  bool bIsExceptThink 是否去除厚度
//    * @return     std::pair<double,double> 返回值为<大边，小边>，如果非变截面，则两值相等
//    */
//    std::pair<double, double> getXDirLength(bool bIsExceptThink = false);

//    /*!
//    * @brief      截面竖直方向最大高度
//    * @author     zhangr-k
//    * @date       2022/03/21
//    * @param[in]  bool bIsExceptThink
//    * @return     std::pair<double, double>
//    */
//    std::pair<double, double> getYDirLength(bool bIsExceptThink = false);


//    /*!
//    * @brief      截面X方向的厚度集合，依次从左向右存储
//    * @author     zhangr-k
//    * @date       2022/03/21
//    * @return     std::vector<double>
//    */
//    std::vector<double> getXDirThicknesses();

//    /*!
//    * @brief      截面Y方向的厚度集合，依次从上到下存储
//    * @author     zhangr-k
//    * @date       2022/03/21
//    * @param      isLineType是否是线式构件，线式构件的上下需要颠倒
//    * @return     std::vector<double>
//    */
//    std::vector<double> getYDirThicknesses(bool isLineType);

//    /*!
//    * @brief      是否为水平对称截面
//    * @author     zhangr-k
//    * @date       2022/05/18
//    * @return     bool
//    */
//    bool isHorizontalSymmetry();

//    /*!
//    * @brief      校验截面类型，父类中所有热轧焊接均为true
//    * @author     zhangr-k
//    * @date       2022/03/18
//    * @return     bool
//    */
//    virtual bool verifyCategory();
//    private:
//    //普通截面
//    prefab::optional<double> getNormalDirLength(bool bIsExceptThink, bool bIsXDir);
//    //变截面
//    std::pair<double, double> getVariableDirLength(bool bIsExceptThink, bool bIsXDir);
//    //厚度集合
//    std::vector<double> getThicknesses(bool bIsXDir, bool isLineType);
//    protected:
//    GJGSectionObj m_oModel;
//};

//class GJGHStyleSectionVarsService : public GJGSectionVarsService
//{
//public:
//    GJGHStyleSectionVarsService(GJGSectionObj & oModel)
//        :GJGSectionVarsService(oModel) { }

//GJGHStyleSectionVarsService(GJGElementSection & oModel)
//        : GJGSectionVarsService(oModel) { }

//GJGHStyleSectionVarsService(std::shared_ptr < GJGSectionObjRepo > repo, int nId)
//        :GJGSectionVarsService(repo, nId)  { }

///*!
//* @brief      获取上翼缘板宽度
//* @author     zhangr-k
//* @date       2022/03/23
//* @param[in]  bool bIsExceptThink
//* @return     double
//*/
//double getTopFlangeWidth(bool bIsExceptThink = false);

///*!
//* @brief      获取下翼缘板宽度
//* @author     zhangr-k
//* @date       2022/03/23
//* @param[in]  bool bIsExceptThink
//* @return     double
//*/
//double getBottomFlangeWidth(bool bIsExceptThink = false);

///*!
//* @brief      获取水平翼缘板宽度(仅针对十字)
//* @author     zhangr-k
//* @date       2022/03/23
//* @param[in]  bool bIsExceptThink
//* @return     double
//*/
//prefab::optional<double> getLevelFlangeWidth(bool bIsExceptThink = false);

///*!
//* @brief      获取腹板高度(附带厚度)
//* @author     zhangr-k
//* @date       2022/03/21
//* @param[in]  bool bIsLarge 是否为大端，点式构件顶部为大端，线式构件起始点为大端
//* @return     double
//*/
//double getWebHeight(bool bIsLarge, bool bIsExceptThink = false);

//bool verifyCategory() final override;
//};

//class GJGCircleStyleSectionVarsService : public GJGSectionVarsService
//{
//public:
//    GJGCircleStyleSectionVarsService(GJGSectionObj & oModel)
//        :GJGSectionVarsService(oModel)
//    { }
//GJGCircleStyleSectionVarsService(GJGElementSection & oModel)
//        : GJGSectionVarsService(oModel)
//    { }
//GJGCircleStyleSectionVarsService(std::shared_ptr < GJGSectionObjRepo > repo, int nId)
//        :GJGSectionVarsService(repo, nId)
//    { }

//double getDiameter(bool bIsLarge);

//bool verifyCategory() final override;
//};

//#include "SectionObj\GJGSectionVarsService.h"

//using namespace std;

//static const string strWorkStyle = "WorkStyle";//工字钢
//static const string strUStyle = "UStyle";//槽钢
//static const string strAngleStyle = "AngleStyle";//角钢
//static const string strNoEqualAngleStyle = "NoEqualAngleStyle";//不等边角钢
//static const string strCirclePipeStyle = "CirclePipeStyle";//圆管
//static const string strCircleStyle = "CircleStyle";//圆钢
//static const string strHStyle = "HStyle";//H型钢
//static const string strCStyle = "CStyle";//C型钢
//static const string strZStyle = "ZStyle";//Z型钢
//static const string strTStyle = "TStyle";//T型钢
//static const string strRectStyle = "RectStyle";//矩形管
//static const string strBoltSphere = "BoltSphere";//螺栓球
//static const string strWeldSphere = "WeldSphere";//焊接球
//static const string strWHstyle = "Weld_Hstyle";//焊接H型钢
//static const string strWNoEqualHStyle = "Weld_NoEqualHStyle";//焊接不等边H型钢
//static const string strWRectStyle = "Weld_RectStyle";//焊接箱型
//static const string strWCirclePipeStyle = "Weld_CirclePipeStyle";//焊接圆管
//static const string strWCrossStyle = "Weld_CrossStyle";//焊接十字
//static const string strWTStyle = "Weld_TStyle";//焊接T型钢
//static const string strWVariableTStyle = "Weld_Variable_TStyle";//焊接变截面T型钢
//static const string strWWedgeStyle = "Weld_WedgeStyle";//焊接楔形
//static const string strWVariableCirclePipe = "WeldVariableCirclePipe";//焊接变截面圆管
//static const string strWVariableRect = "WeldVariableRect";//焊接变截面箱型
//static const string strWVariableH = "WeldVariableH";//焊接变截面H型
//static const string strWVariableEllipse = "WeldVariableEllipse";//焊接变截面椭圆
//static const string strWUstyle = "Weld_Ustyle";//焊接U型
//static const string strWHBStyle = "Weld_HBStyle";//焊接盒式

//GJGSectionVarsService::GJGSectionVarsService(shared_ptr<GJGSectionObjRepo> repo, int nId)
//{
//    m_oModel = repo->find(nId);
//}

//GJGSectionVarsService::GJGSectionVarsService(GJGSectionObj & oModel)
//    :m_oModel(oModel)
//{
//}

//GJGSectionVarsService::GJGSectionVarsService(GJGElementSection & oModel)
//{
//    m_oModel.norm = oModel.norm;
//    m_oModel.category = oModel.category;
//    m_oModel.variables = oModel.variables;
//    m_oModel.insert = oModel.insert;
//    m_oModel.direct = oModel.direct;
//}

//unordered_map<string, double> GJGSectionVarsService::params()
//{
//    if (!m_oModel.variables.empty())
//        return m_oModel.variables;
//    else
//        return unordered_map < std::string, double> ();
//}

//std::pair<double, double> GJGSectionVarsService::getXDirLength(bool bIsExceptThink /*= false*/)
//{
//    //先看看是不是常规截面
//    auto normal = getNormalDirLength(bIsExceptThink, true);
//    if (normal)
//    {
//        auto value = normal.value();
//        return std::make_pair(value, value);
//    }
//    else
//    {
//        //不是常规的，就从变截面的去解析
//        return getVariableDirLength(bIsExceptThink, true);
//    }
//}

//std::pair<double, double> GJGSectionVarsService::getYDirLength(bool bIsExceptThink /*= false*/)
//{
//    //先看看是不是常规截面
//    auto normal = getNormalDirLength(bIsExceptThink, false);
//    if (normal)
//    {
//        auto value = normal.value();
//        return std::make_pair(value, value);
//    }
//    else
//    {
//        //不是常规的，就从变截面的去解析
//        return getVariableDirLength(bIsExceptThink, false);
//    }
//}

//std::vector<double> GJGSectionVarsService::getXDirThicknesses()
//{
//    return getThicknesses(true, false);
//}

//std::vector<double> GJGSectionVarsService::getYDirThicknesses(bool isLineType)
//{
//    return getThicknesses(false, isLineType);
//}

//bool GJGSectionVarsService::isHorizontalSymmetry()
//{
//    if (m_oModel.category.empty())
//        return true;
//    auto category = m_oModel.category;
//    std::set < std::string> symmetryCategory = {
//        strWorkStyle,strCirclePipeStyle,strCircleStyle,strHStyle,strTStyle,strRectStyle,
//        strWHstyle,strWNoEqualHStyle,strWRectStyle,strWCirclePipeStyle,strWCrossStyle,strWTStyle,strWVariableTStyle,
//        strWWedgeStyle,strWVariableCirclePipe,strWVariableRect,strWVariableH,strWVariableEllipse,strWUstyle,strWHBStyle
//    };
//    return (symmetryCategory.find(category) != symmetryCategory.end());
//}

//bool GJGSectionVarsService::verifyCategory()
//{
//    if (m_oModel.category.empty())
//        return false;
//    set<string> dict = {
//        strWorkStyle,strUStyle,strAngleStyle,strNoEqualAngleStyle,strCirclePipeStyle
//        ,strCircleStyle,strHStyle,strCStyle,strZStyle,strTStyle,strRectStyle
//        ,strWHstyle,strWNoEqualHStyle,strWRectStyle,strWCirclePipeStyle,strWCrossStyle
//        ,strWTStyle,strWVariableTStyle,strWWedgeStyle,strWVariableCirclePipe,strWVariableRect,strWVariableH
//        ,strWVariableEllipse,strWUstyle,strWHBStyle
//    };
//    if (dict.find(m_oModel.category) != dict.end())
//        return true;
//    else
//        return false;
//}

//prefab::optional<double> GJGSectionVarsService::getNormalDirLength(bool bIsExceptThink, bool bIsXDir)
//{
//    map<string, pair<vector<string>, vector<string>>> sectionDict;
//    if (bIsXDir)
//    {
//        sectionDict = {
//            { strWorkStyle,{ { "b"},{ "d"} } }
//            ,{ strUStyle,{ { "b"},{ "d"} } }
//            ,{ strAngleStyle,{ { "l"},{ "t"} } }
//            ,{ strNoEqualAngleStyle,{ { "l1"},{ "t"} } }
//            ,{ strCirclePipeStyle,{ { "d","d"},{ "t","t"} } }
//            ,{ strCircleStyle,{ { "d","d"},{ } } }
//            ,{ strHStyle,{ { "b"},{ "tw"} } }
//            ,{ strCStyle,{ { "b"},{ "t"} } }
//            ,{ strZStyle,{ { "b","b","t"},{ "t"} } }
//            ,{ strTStyle,{ { "b"},{ "t1"} } }
//            ,{ strRectStyle,{ { "d"},{ "t","t"} } }
//            ,{ strWHstyle,{ { "b"},{ "tw"} } }
//            ,{ strWNoEqualHStyle,{ { "b1"},{ "tw"} } }
//            ,{ strWRectStyle,{ { "b2"},{ "t1","t1"} } }
//            ,{ strWCirclePipeStyle,{ { "d"},{ "t","t"} } }
//            ,{ strWCrossStyle,{ { "h2"},{ "tw1","t3","t4"} } }
//            ,{ strWTStyle,{ { "b"},{ "t1"} } }
//            ,{ strWUstyle,{ { "b"},{ "t","t"} } }
//            ,{ strWHBStyle,{ { "b"},{ "t1","t1"} } }
//        };
//    }
//    else
//    {
//        sectionDict = {
//            { strWorkStyle,{ { "h"},{ "t","t"} } }
//            ,{ strUStyle,{ { "h"},{ "t","t"} } }
//            ,{ strAngleStyle,{ { "l"},{ "t"} } }
//            ,{ strNoEqualAngleStyle,{ { "l2"},{ "t"} } }
//            ,{ strCirclePipeStyle,{ { "d","d"},{ "t","t"} } }
//            ,{ strCircleStyle,{ { "d","d"},{ } } }
//            ,{ strHStyle,{ { "h"},{ "t1","t2"} } }
//            ,{ strCStyle,{ { "h"},{ "t","t"} } }
//            ,{ strZStyle,{ { "h"},{ "t"} } }
//            ,{ strTStyle,{ { "h"},{ "t2"} } }
//            ,{ strRectStyle,{ { "b"},{ "t","t"} } }
//            ,{ strWHstyle,{ { "h"},{ "t1","t2"} } }
//            ,{ strWNoEqualHStyle,{ { "h"},{ "t1","t2"} } }
//            ,{ strWRectStyle,{ { "b1"},{ "t2","t2"} } }
//            ,{ strWCirclePipeStyle,{ { "d"},{ "t","t"} } }
//            ,{ strWCrossStyle,{ { "h1"},{ "t1","tw2","t2"} } }
//            ,{ strWTStyle,{ { "h"},{ "t2"} } }
//            ,{ strWUstyle,{ { "h"},{ "t","t"} } }
//            ,{ strWHBStyle,{ { "h"},{ "t2","t2"} } }
//        };
//    }

//    if (sectionDict.find(m_oModel.category) != sectionDict.end())
//    {
//        auto paramValue = m_oModel.variables;
//        auto vars = sectionDict[m_oModel.category];
//        double dLength = 0.0;
//        //这里查到的是X方向整长
//        for (auto && v : vars.first)
//        {
//            dLength += paramValue[v];
//        }
//        if (bIsExceptThink)
//        {
//            //如果需要出去厚度，则减去厚度部分
//            for (auto && v : vars.second)
//            {
//                dLength -= paramValue[v];
//            }
//        }
//        return dLength;
//    }
//    else
//    {
//        return { };
//    }
//}

//std::pair<double, double> GJGSectionVarsService::getVariableDirLength(bool bIsExceptThink, bool bIsXDir)
//{
//    //tuple<长边索引，短边索引，厚度索引>
//    map<string, tuple<vector<string>, vector<string>, vector<string>>> sectionDict;
//    if (bIsXDir)
//    {
//        sectionDict = {
//            { strWWedgeStyle,{ { "b"},{ "b"},{ "tw"} } }
//            ,{ strWVariableCirclePipe,{ { "R1"},{ "R2"},{ "t","t"} } }
//            ,{ strWVariableRect,{ { "b2"},{ "B2"},{ "t1","t1"} } }//单独说下变截面箱型，其截面和其他截面变动方向正好相反，为了和其他截面保持一致，变截面返回<小端、大端>
//            ,{ strWVariableH,{ { "b"},{ "b"},{ "tw"} } }
//            ,{ strWVariableEllipse,{ { "R1"},{ "r1"},{ "t","t"} } }
//            ,{ strWVariableTStyle,{ { "b"},{ "b"},{ "t1"} } }
//        };
//    }
//    else
//    {
//        sectionDict = {
//            { strWWedgeStyle,{ { "h1"},{ "h2"},{ "t1","t2"} } }
//            ,{ strWVariableCirclePipe,{ { "R1"},{ "R2"},{ "t","t"} } }
//            ,{ strWVariableRect,{ { "b1"},{ "B1"},{ "t2","t2"} } }
//            ,{ strWVariableH,{ { "h1"},{ "h2"},{ "t1", "t2"} } }
//            ,{ strWVariableEllipse,{ { "R2"},{ "r2"},{ "t","t"} } }
//            ,{ strWVariableTStyle,{ { "h1"},{ "h2"},{ "t2"} } }
//        };
//    }

//    if (sectionDict.find(m_oModel.category) != sectionDict.end())
//    {
//        auto paramValue = m_oModel.variables;
//        auto vars = sectionDict[m_oModel.category];
//        double dLength1 = 0.0;//长边
//        double dLength2 = 0.0;//短边
//        //这里查到的是X方向整长
//        for (auto && v : std::get < 0 > (vars))
//        {
//            dLength1 += paramValue[v];
//        }
//        for (auto && v : std::get < 1 > (vars))
//        {
//            dLength2 += paramValue[v];
//        }
//        if (bIsExceptThink)
//        {
//            auto subs = std::get < 2 > (vars);
//            //如果需要出去厚度，则减去厚度部分
//            for (auto && v : subs)
//            {
//                dLength1 -= paramValue[v];
//            }
//            for (auto && v : subs)
//            {
//                dLength2 -= paramValue[v];
//            }
//        }
//        return make_pair(dLength1, dLength2);
//    }
//    else
//    {
//        return { 0.0,0.0 };
//    }
//}

//std::vector<double> GJGSectionVarsService::getThicknesses(bool bIsXDir, bool isLineType)
//{
//    vector<double> result;
//    map<string, pair<vector<string>, vector<string>>> sectionDict = {
//            {strWorkStyle, { {"d"},{"t","t"} }}
//            , { strUStyle,{{"d"},{"t","t"}} }
//            , { strAngleStyle,{{"t"},{"t"}} }
//            , { strNoEqualAngleStyle,{{"t"},{"t"}} }
//            , { strCirclePipeStyle,{{"t","t"},{"t","t"}} }
//            , { strCircleStyle,{{},{}} }
//            , { strHStyle,{ {"tw"},{"t1","t2"} }}
//            , { strCStyle,{ {"t"},{"t","t"} }}
//            , { strZStyle,{ {"t"},{"t","t"} }}
//            , { strTStyle,{ {"t1"},{"t2"} }}
//            , { strRectStyle,{{"t","t"},{"t","t"}} }
//            , { strWHstyle,{{"tw"},{"t1","t2"}} }
//            , { strWNoEqualHStyle,{{"tw"},{"t1","t2"}} }
//            , { strWRectStyle,{{"t1","t1"},{"t2","t2"}} }
//            , { strWCirclePipeStyle,{{"t","t"},{"t","t"}} }
//            , { strWCrossStyle,{{"t3","tw1","t4"},{"t1","tw2","t2"}} }
//            , { strWTStyle,{{"t1"},{"t2"} }}
//            , { strWVariableTStyle,{{"t1"},{"t2"} }}
//            , { strWUstyle,{{"t","t"},{"t"} }}
//            , { strWHBStyle,{{"t1","t1"},{"t2","t2"} }}
//            , { strWWedgeStyle,{{"tw"},{"t1","t2"} }}
//            , { strWVariableCirclePipe,{{"t","t"},{"t","t"} }}
//            , { strWVariableRect,{{"t1","t1"},{"t2","t2"} }}
//            , { strWVariableH,{{"tw"},{"t1","t2"} }}
//            , { strWVariableEllipse,{{"t","t"},{"t","t"} }}
//    };
//    //线式构件上下翼缘需要颠倒
//    if (isLineType)
//    {
//        sectionDict[strWWedgeStyle] = { { "tw"},{ "t2","t1"} };
//    }

//    if (sectionDict.find(m_oModel.category) == sectionDict.end())
//        return result;
//    auto vars = sectionDict[m_oModel.category];
//    auto params = m_oModel.variables;
//    if (bIsXDir)
//    {
//        for (auto && v : vars.first)
//            result.emplace_back (params[v]);
//    }
//    else
//    {
//        for (auto && v : vars.second)
//            result.emplace_back (params[v]);
//    }
//    return result;
//}

//double GJGHStyleSectionVarsService::getTopFlangeWidth(bool bIsExceptThink /*= false*/)
//{
//    if (m_oModel.category == strWCrossStyle)
//    {
//        auto vars = m_oModel.variables;
//        return bIsExceptThink ? vars["b1"] - vars["tw"] : vars["b1"];
//    }
//    else
//    {
//        auto vars = getXDirLength(bIsExceptThink);
//        return vars.first;
//    }
//}

//double GJGHStyleSectionVarsService::getBottomFlangeWidth(bool bIsExceptThink /*= false*/)
//{
//    if (m_oModel.category == strWNoEqualHStyle)
//    {
//        //特例1：不等边H的上下翼缘不相等
//        auto vars = m_oModel.variables;
//        return bIsExceptThink ? vars["b2"] - vars["tw"] : vars["b2"];
//    }
//    else if (m_oModel.category == strWCrossStyle)
//    {
//        //特例2，十字的翼缘板不是最大宽度
//        auto vars = m_oModel.variables;
//        return bIsExceptThink ? vars["b1"] - vars["tw1"] : vars["b1"];
//    }
//    else
//    {
//        auto vars = getXDirLength(bIsExceptThink);
//        return vars.first;
//    }
//}


//prefab::optional<double> GJGHStyleSectionVarsService::getLevelFlangeWidth(bool bIsExceptThink /*= false*/)
//{
//    if (m_oModel.category == strWCrossStyle)
//    {
//        //特例1：不等边H的上下翼缘不相等
//        auto vars = m_oModel.variables;
//        return bIsExceptThink ? vars["b2"] - vars["tw2"] : vars["b2"];
//    }
//    else
//        return { };
//}

//double GJGHStyleSectionVarsService::getWebHeight(bool bIsLarge, bool bIsExceptThink/* = false*/)
//{
//    auto vars = getYDirLength(bIsExceptThink);
//    return bIsLarge ? vars.first : vars.second;
//}

//bool GJGHStyleSectionVarsService::verifyCategory()
//{
//    if (m_oModel.category.empty())
//        return false;
//    set<string> dict = { strWorkStyle, strHStyle, strWHstyle, strWNoEqualHStyle, strWWedgeStyle, strWVariableH, strWCrossStyle };
//    if (dict.find(m_oModel.category) != dict.end())
//        return true;
//    else
//        return false;
//}

//double GJGCircleStyleSectionVarsService::getDiameter(bool bIsLarge)
//{
//    //椭圆目前应该没有应用场景，但是也做个预留，如果出现了椭圆类型，加一个缺省值；
//    auto vars = getXDirLength();
//    if (bIsLarge)
//        return vars.first;
//    else
//        return vars.second;
//}

//bool GJGCircleStyleSectionVarsService::verifyCategory()
//{
//    if (m_oModel.category.empty())
//        return false;
//    set<string> dict = { strCirclePipeStyle, strCircleStyle, strWCirclePipeStyle, strWVariableCirclePipe, strWVariableEllipse };
//    if (dict.find(m_oModel.category) != dict.end())
//        return true;
//    else
//        return false;
//}
